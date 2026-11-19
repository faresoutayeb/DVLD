#define ControlsNullExceptions

using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace DVLD_Bussiness_Layer
{
    sealed public   class clsUtil
    {

        static public bool IsValidID(int CurrentID)
        {
            return (CurrentID >= 0);


        }
        private void _EmptyTxtFile(string FilePath)
        {
            File.WriteAllText(FilePath, string.Empty);
        }
        static public bool IsObjectFull(Object CurrentObject)
        {
            return (CurrentObject != null);
        }
        static public  int ParseToInt(string IntString)
        {
            if (int.TryParse(IntString, out int IntValue))
            {
                return IntValue;
            }
            return -1;
        }

        public static bool IsPressedEnter(KeyPressEventArgs EventArgument)
        {
            // Check if the pressed key is Enter (character code 13)
            return (EventArgument.KeyChar == (char)13);
        }
        public static bool IsFileExistsInDirectory(string fileName, string directory)
        {
            return File.Exists(Path.Combine(directory, fileName));
        }

        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();

        }
        public static void AllowOnlyNumberAndControlsToPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;

        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            FileInfo CurrentFileInfo = new FileInfo(sourceFile);
            // string extn = fi.Extension; this is to  get the file extention for exemple you have "C:\DVLD Project Final\DVLD-People-Images\FaresIncodeProfilePicture.png"
            // is goign to give you this (.png)
            string FileExtension = CurrentFileInfo.Extension;
            return GenerateGUID() + FileExtension;

        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            // this funciton will copy the image to the
            // project images foldr after renaming it
            // with GUID with the same extention, then it will update the sourceFileName with the new name.

            string DestinationFolder = @"C:\DVLD Project Final\DVLD-People-Images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }
        private bool _IsTxtFileEmpty(string FilePath)
        {
            return (string.IsNullOrWhiteSpace(File.ReadAllText(FilePath)));


        }

        private long[] CopyList(long[] Biglist, int length)
        {
            long[] list = new long[length];


            for (int i = 0; i < length; i++)
            {

                list.Append(Biglist[i]);


            }
            return list;

        }

        ///<Summary>This function is centrilize the lable</Summary>

        public static void CenterilizeControl(Control CurrentControl)
        {
            CurrentControl.Left = (CurrentControl.Parent.Width - CurrentControl.Width) / 2;

        }


        [Conditional("ControlsNullExceptions")]
        public static void CenterilizeAllControlsDebugMode(Control[] CurrentControls)
        {
             int ContlrolsCounter = 0;

            foreach (Control Control in CurrentControls)
            {
                ContlrolsCounter++;
                 CenterilizeControl(Control);
            }

        }

        public static void CenterilizeAllControls(Control[] CurrentControls)
        {
            foreach (Control Control in CurrentControls)
            {
                CenterilizeControl(Control);
            }

        }
    }
}
