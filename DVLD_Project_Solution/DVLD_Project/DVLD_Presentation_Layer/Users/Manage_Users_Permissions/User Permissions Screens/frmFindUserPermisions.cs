using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Manage_Users_Permissions.User_Permissions_User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Manage_Users_Permissions.User_Permissions_Screens
{
    public partial class frmFindUserPermisions : Form
    {
        public frmFindUserPermisions()
        {
            InitializeComponent();
            this._UserID = -1;

        }


        public frmFindUserPermisions(int UserID)
        {
                 InitializeComponent();
                 this._UserID = UserID;  
            
        }

        private int _UserID=-1;
        

        private void FindUserPermisionsScreen_Load(object sender, EventArgs e)
        {

            if(_UserID !=-1)
            {

                ctrlFindUserFilter1.txtbSearchBy.Text= _UserID.ToString();
                ctrlFindUserFilter1.btnSearch.PerformClick();
            }

        }

        private void _WhenUserNotFound()
        {
            MessageBox.Show("User not found","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                
        }

 

        private async void ctrlFindUserFilter1_OnSearchedForUserByUserID(int obj)
        {
            _UserID=obj;
            await ctrlUserPermissionsCard1.LoadUserPermissions(obj);

        }

        private async void ctrlFindUserFilter1_OnSearchedForUserByUserName(string obj)
        {
            _UserID=await clsUser.GetUserIDAsync(obj);   
           await ctrlUserPermissionsCard1.LoadUserPermissions(_UserID);

        }

        private void ctrlUserPermissions1_OnUserNotFound()
        {
            _WhenUserNotFound();

        }

        private void ctrlUserPermissionsCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
