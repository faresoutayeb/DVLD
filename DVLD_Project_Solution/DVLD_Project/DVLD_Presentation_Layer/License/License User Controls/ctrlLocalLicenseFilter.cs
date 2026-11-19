using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.License.License_User_Controls
{
    public partial class ctrlLocalLicenseFilter : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void LicenseSelected(int LicenseID)
        {
            OnLicenseSelected?.Invoke(LicenseID);
        }

        public event Action OnControlsNotValidated;
        protected virtual void ControlsNotValidated()
        {
            OnControlsNotValidated?.Invoke();
        }


        public ctrlLocalLicenseFilter()
        {
            InitializeComponent();
        }

        private bool _FilterEnabled = true;
        private int _LicenseID = -1;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }
        public int LicenseID
        {
            get { return _LicenseID; }
        }
        public clsLicense SelectedLicenseInfo  
        { get { return ctrlLicenseInfo1.SelectedLicenseInfo; } }


        public event Action OnNoLicenseFounded;
        protected virtual void NoLicenseFounded()
        {
            OnNoLicenseFounded?.Invoke();

        }


        public void txtLicenseIDFocus()
        {
            txtLicenseID.Focus();
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {

            clsUtil.AllowOnlyNumberAndControlsToPress(sender, e);

            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }

        }

        public void LoadLicenseInfo(int LicenseID)
        {
            txtLicenseID.Text=LicenseID.ToString();
            btnSearch.PerformClick();

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtLicenseID.Text.Trim()=="")
            {
                //Here we dont continue becuase the form is not valid
              
                    ControlsNotValidated();
                
                txtLicenseID.Focus();
                return;

            }
            _LicenseID = int.Parse(txtLicenseID.Text.Trim());

            await ctrlLicenseInfo1.LoadLicenseInfoToControls(_LicenseID);
            if(ctrlLicenseInfo1.IsLicenseFound)
            {
                LicenseSelected(_LicenseID);

            }

        }

        private void ctrlLicenseInfo1_OnNoLicenseFound()
        {
            NoLicenseFounded();
        }


    }
}
