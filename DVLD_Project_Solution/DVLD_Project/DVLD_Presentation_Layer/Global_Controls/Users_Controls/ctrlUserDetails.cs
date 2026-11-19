using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Properties;
using DVLD_Presentation_Layer.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DVLD_Presentation_Layer.Global_Controls.Users_Controls
{
    public partial class ctrlUserDetails : UserControl
    {
        public ctrlUserDetails()
        {
            InitializeComponent();
        }

        public event Action OnUserNotFound;
        protected virtual void UserNotFound()
        {
            OnUserNotFound?.Invoke();

        }

        private int _UserID;
        public int UserID { get { return _UserID; }  }

        private clsUser _CurrentUser;
        public clsUser CurrentUser
        {
            get => _CurrentUser;
        }


        public async Task LoadInfo(int UserID)
        {

            //load user info
            _UserID=UserID;
        _CurrentUser = await clsUser.FindByUserIDAsync(_UserID);
            if(CurrentUser != null)
            {
                lblFullName.Text = CurrentUser.PersonInfo.Name;
                lblEmail.Text=CurrentUser.PersonInfo.Email;
                lblPhone.Text=CurrentUser.PersonInfo.Phone;
                lblUserID.Text=CurrentUser.UserID.ToString();
                lblUserName.Text=CurrentUser.UserName;
                lblRole.Text = CurrentUser.RoleInfo.RoleName.ToString();
                if (CurrentUser.PersonInfo.ImagePath != "" && File.Exists(CurrentUser.PersonInfo.ImagePath))
                {
                    pbProfileInfoPicture.ImageLocation = CurrentUser.PersonInfo.ImagePath;
                }
                else
                {
                    if (CurrentUser.PersonInfo.Gender== clsPerson.enGender.Male)
                    {

                        pbProfileInfoPicture.BackgroundImage = Resources.little_boy;

                    }
                    else
                    {
                        pbProfileInfoPicture.BackgroundImage = Resources.little_female;

                    }

                }

                if (CurrentUser.IsActive)
                {
                    cpanelActive.Visible = true;
                    cpanelInactive.Visible = false;
                }



            }
            else
            {
              
                    UserNotFound();
                
            }

        }

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {
            frmShowUserInfoScreen CurrentUserInfo = new frmShowUserInfoScreen(_UserID);
            CurrentUserInfo.ShowDialog();
        }


    }
}
