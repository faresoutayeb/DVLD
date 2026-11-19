using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.License.LicenseScreens
{
    public partial class frmLicenseInfoScreen : Form
    {
        public frmLicenseInfoScreen()
        {

            InitializeComponent();
            _LicenseID = -1;

        }


        public delegate void  OnShowLicenseScreenCloseEventHandler ();
        public event  OnShowLicenseScreenCloseEventHandler OnShowLicenseScreenClose;

        private int _LicenseID;


        public frmLicenseInfoScreen(int LicenseID)
        {
            InitializeComponent();
            this._LicenseID = LicenseID;

        }


        private async void LicenseScreen_Load(object sender, EventArgs e)
        {
            await ctrlLicenseInfo1.LoadLicenseInfoToControls(_LicenseID);
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();

            OnShowLicenseScreenClose?.Invoke();

        }
    }
}
