using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Users.User_Screens;
using DVLD_Presentation_Layer.Users.UserControles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Users
{
    public partial class frmShowUserInfoScreen : Form
    {

        public int _UserID;
        public clsUser _User;
        public frmShowUserInfoScreen()
        {


            InitializeComponent();
        }

        public frmShowUserInfoScreen(int UserId)
        {
            this._UserID = UserId;
            InitializeComponent();

        }
        public delegate void OnCloseScreenEventHandler();
        public event OnCloseScreenEventHandler OnCloseScreen;

        private void ShowUserInfoScreen_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private async void LoadInfo()
        {
           await ctrlSmallUserInfoCard1.LoadInfo(_UserID);
            _User = ctrlSmallUserInfoCard1.CurrenUser;
        }
        private  void btnEditUserInfo_Click(object sender, EventArgs e)
        {

                if(clsUserPermissions.HasPermission(clsGlobalUserInfo.CurrentLogInUser, clsUserPermissions.enPermissions.AddEditUser))
                {
                    frmAddEditUser EditCurrentUserForm= new frmAddEditUser(_UserID);
                    EditCurrentUserForm.OnScreenClosed +=LoadInfo;
                    EditCurrentUserForm.ShowDialog();
                }
            

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
