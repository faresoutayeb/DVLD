using DVLD_Bussiness_Layer;
using System;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    /// <summary>
    /// Provides the entry point of the DVLD application
    /// and configures centralized exception handling.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Starts the application, initializes error logging,
        /// configures Windows Forms, and opens the main form.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configure Windows Forms to catch unhandled UI exceptions.
            System.Windows.Forms.Application.SetUnhandledExceptionMode(
                UnhandledExceptionMode.CatchException);

            /// <summary>
            /// Handles unhandled exceptions on the UI thread.
            /// Attempts to log the exception and displays an error message.
            /// </summary>
            //System.Windows.Forms.Application.ThreadException += (sender, e) =>
            //{
            //    try
            //    {
            //        clsEventLog.LogError(
            //            e.Exception,
            //            "Global UI Exception Handler");
            //    }
            //    catch
            //    {
            //        //Prevent logging failure from causing another exception.
            //    }

            //    MessageBox.Show(
            //       $"An unexpected error occurred. Please try again. {e.Exception.Message}",
            //        "Application Error",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //};

            /// <summary>
            /// Initializes the logging system before the application starts.
            /// Displays a warning if logging initialization fails.
            /// </summary>
            try
            {
                clsEventLog.Initialize();
            }
            catch (Exception)
            {

                MessageBox.Show("Logging initialization failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Enable Windows visual styles.
            System.Windows.Forms.Application.EnableVisualStyles();

            // Configure the default text-rendering behavior.
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // Start the main form and the Windows Forms message loop.
            System.Windows.Forms.Application.Run(new frmDVLD_Login_Screen());
        }
    }
}