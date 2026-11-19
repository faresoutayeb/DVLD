using DVLD.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Renew_Driving_License.Renew_Driving_License_Screens
{
    public partial  class frmRenewDrivingLicenseScreen
    {

        //------------------------------------------ Initialize Local Events with function to call ones fired-------------------------------



        private void _WhenLicenseNotRenewed()
        {
            MessageBox.Show("License Not Renewed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void _WhenLicenseNotActive()
        {
            MessageBox.Show("Selected License is not Not Active, choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void _WhenLicenseRenewed(int NewRenewedLicenseID)
        {
            MessageBox.Show($"License Renewed Successfully With ID = {NewRenewedLicenseID} ", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void _WhenLicenseNotExpired()
        {
            MessageBox.Show("Selected License is not yet expiared, it will expire on: " + clsFormat.DateToShort(ctrlOrdinaryLicenseFilter1.SelectedLicenseInfo.ExpirationDate), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}
