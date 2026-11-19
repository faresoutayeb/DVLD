using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.License.LicenseScreens.international_License_Screen
{
    public partial class frmInterLicenseInfo : Form
    {
        public frmInterLicenseInfo()
        {
            InitializeComponent();
        }

        private int _InternationalLicenseID;
        public frmInterLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            this._InternationalLicenseID= InternationalLicenseID;
        }
        private void ctrlInternationalLicenseInfo1_OnInternationalLicenseNotFound()
        {
            MessageBox.Show("international License Not Found","Not Found",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private async void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

          await  ctrlInternationalLicenseInfo1.LoadInfo(_InternationalLicenseID);


        }

        private void ctrlInternationalLicenseInfo1_OnLicenseImageNotFound()
        {
            MessageBox.Show("License Image Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
