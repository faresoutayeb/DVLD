using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Users.User_Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    public partial class frmPersonInformationScreen : Form
    {
        public frmPersonInformationScreen()
        {
            InitializeComponent();
            _PersonID=-1;
        }
        private int _PersonID;
        public frmPersonInformationScreen(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;

        }



        private   void LoadInfo(object obj, int PersonID)
        {
            ctrlPersonInfoCard1.LoadPersonInfo(PersonID);
            _PersonID= ctrlPersonInfoCard1.PersonID;
        }


        private void btnEditUserInfo_Click(object sender, EventArgs e)
        {
     
            if (!clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.AddEditPerson))
            {
                clsGlobal.ShowAccessDeniedScreen();
                    return;


            }
            else
            {
                    frmAddEditPerson EditCurrentPersonForm = new frmAddEditPerson(_PersonID);
                    EditCurrentPersonForm.OnDataBack += LoadInfo;
                    EditCurrentPersonForm.ShowDialog();
            }
            
        }

        private void frmPersonInformationScreen_Load(object sender, EventArgs e)
        {
            if(_PersonID >0)
                ctrlPersonInfoCard1.LoadPersonInfo(_PersonID);
        }
    }
}
