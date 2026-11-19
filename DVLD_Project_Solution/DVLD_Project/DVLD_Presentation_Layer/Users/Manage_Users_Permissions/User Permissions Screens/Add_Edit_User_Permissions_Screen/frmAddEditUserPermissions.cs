using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Users.User_Controles;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Manage_Users_Permissions.User_Permissions_Screens
{
    public partial class frmAddEditUserPermissions : Form
    {
        public frmAddEditUserPermissions()
        {
         
            InitializeComponent();
            _CurrentScreenMode = enMode.AddNew;
            _UserID = -1;
            _CurrentUser = null;

        }


        public frmAddEditUserPermissions(int UserID)
        {

            InitializeComponent();
   
            _CurrentScreenMode = enMode.Update;
                _UserID=UserID;


        }





        //--------------------------------- Controls Events ------------------------

        private async void btnSave_Click(object sender, EventArgs e)
        {
           await PerformSaveCurrentUserPermissionsInfo();

        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_CurrentScreenMode== enMode.AddNew )
            {
                if(clsUtil.IsObjectFull(_CurrentUser))
                {
                    tcAddEditUserPermissions.SelectedTab = tbAddEditPermissions;

                }
                else
                {
                    _WhenNoUserSelected();
                    ctrlFindUserFilter1.txtbSearchBy.Focus();
                    return;
                }

            }
            tcAddEditUserPermissions.SelectedTab = tbAddEditPermissions;
        }


        private async void ctrlFindUserFilter1_OnSearchedForUserByUserID(int obj)
        {

           await InitializeLocalPrivateVariables(obj);
            if(_CurrentUser ==null)
            {
                return;
            }
            await ctrlUserPermissionsCard1.LoadUserPermissions(_UserID);
            _LoadCurrentUserPermissionToAddAndUpdate();




        }



        private async void ctrlFindUserFilter2_OnSearchedForUserByUserName(string obj)
        {
            await InitializeLocalPrivateVariables(obj);
            if (_CurrentUser == null)
            {
                return;
            }
            await ctrlUserPermissionsCard1.LoadUserPermissions(_UserID);
            _LoadCurrentUserPermissionToAddAndUpdate();



        }

        private async void frmAddEditUserPermissions_Load(object sender, EventArgs e)
        {
            if(_CurrentScreenMode==enMode.Update)
            {
                _CurrentUser = await clsUser.FindByUserIDAsync(_UserID);
                if (_CurrentUser != null)
                {
                    //lblTitle.Text = "Update User Permissions";
                    ctrlFindUserFilter1.comboBox1.SelectedIndex = 0;    
                    ctrlFindUserFilter1.txtbSearchBy.Text = _UserID.ToString();
                    ctrlFindUserFilter1.btnSearch.PerformClick();
                }
            }

        }
    }
}
