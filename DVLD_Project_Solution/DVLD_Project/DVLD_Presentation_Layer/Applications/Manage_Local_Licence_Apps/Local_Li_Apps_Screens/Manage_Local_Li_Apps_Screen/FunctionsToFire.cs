using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Applications.Manage_Local_Driving_Licence_Applications.Local_Driving_License_Applications_Screens.Manage_Local_Driving_License_Applications_Screen
{
    public partial class frmManageLocalLiApp
    {
        //------------------ function to call when firing local events--------------------------

        private void _WhenLocalDrivingApplicationNotDeleted()
        {
            MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _WhenLocalDrivingApplicationDeleted()
        {
            MessageBox.Show("Application Deleted");
        }

        private void _WhenApplicationStatusUpdated(clsApplication.enApplicationStatus NewStatusApplication)
        {
            MessageBox.Show($"Application Status Updated to {NewStatusApplication.ToString()}");
        }

        private void _WhenApplicationStatusNotUpdated()
        {
            MessageBox.Show($"Application Status not Updated ");
        }

        private void InitializeLocalEventFunctionToCall()
        {

            OnApplicationStatusUpdated += _WhenApplicationStatusUpdated;
            OnApplicationStatusNotUpdated += _WhenApplicationStatusNotUpdated;
            OnLocalDrivingLicenseApplicationDeleted += _WhenLocalDrivingApplicationDeleted;
            OnLocalDrivingLicenseApplicationNotDeleted += _WhenLocalDrivingApplicationNotDeleted;


        }



    }
}
