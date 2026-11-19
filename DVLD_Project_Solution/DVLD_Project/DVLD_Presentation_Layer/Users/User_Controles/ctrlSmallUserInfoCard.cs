using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Users.User_Controles
{
    public partial class ctrlSmallUserInfoCard : UserControl
    {
        public ctrlSmallUserInfoCard()
        {
            InitializeComponent();
        }



        private int _UserID;
        public int UserID => _UserID;

        private clsUser _CurrentUser;
        public clsUser CurrenUser => _CurrentUser;


        //----------------------------------initialize events and delegate -----------------------------------------------------
        public event Action OnNoUserFound;
        protected virtual void NoUserFound()
        {
            OnNoUserFound?.Invoke();

        }

        public event Action OnUserFound;
        protected virtual void UserFound()
        {
            OnUserFound?.Invoke();

        }

        public void LoadDefaultInfo()
        {
            string DefaultLablesStrin="";
            lblName.Text = DefaultLablesStrin;
            lblUserID.Text = DefaultLablesStrin;
            lblUserState.Text = DefaultLablesStrin;
            lblUserName.Text = DefaultLablesStrin;
            pbProfilePicture.Image = null;

            lblName.Text = DefaultLablesStrin;
            lblUserID.Text = DefaultLablesStrin;
            lblLastLogin.Text = DefaultLablesStrin;
            lblUserState.Text = DefaultLablesStrin;
            lblUserState1.Text = DefaultLablesStrin;

            lblUserRole.Text = DefaultLablesStrin;
            txtPassword.Text = DefaultLablesStrin;
            lblUserName.Text = DefaultLablesStrin;
           

            listbPermissions.DataSource = null;
    
                lblActiveOrNot.Text = DefaultLablesStrin;
                lblActiveOrNotDescription.Text = DefaultLablesStrin;
                btnActiveOrNot.FillColor = Color.Green;
                btnActiveOrNot.FillColor2 = Color.DarkGreen;

        }


        
        public async Task LoadInfo(int UserID)
        {
            _CurrentUser = await clsUser.FindByUserIDAsync(UserID);
            if(clsUtil.IsObjectFull(_CurrentUser))
            {
                _UserID = _CurrentUser.UserID;
               await _FillControlsWithInfo();
              
                    UserFound();
                
            }
            else
            {
                LoadDefaultInfo();
       
                    NoUserFound();
                
            }

        }


        private  async Task _FillControlsWithInfo( )
        {
            lblName.Text = _CurrentUser.PersonInfo.Name;
            lblUserID.Text=_CurrentUser.UserID.ToString();
            clsUserLog log = await clsUserLog.FindLastLoginAsync(_CurrentUser.UserID);
           
            lblLastLogin.Text=(log != null)? log.LoginDateTime.ToString(): "Never logged in";

            
            lblUserState.Text = (_CurrentUser.IsAdmin()) ? "Admin" : "Regular User";
            lblUserState1.Text = lblUserState.Text;
            lblRole.Text = _CurrentUser.RoleInfo.RoleName;
            lblPersonID.Text = _CurrentUser.PersonInfo.PersonID.ToString();
            lblSignUpDate.Text=_CurrentUser.SignUpDateTime.ToString();
            lblUserRole.Text = _CurrentUser.RoleInfo.RoleName;
            txtPassword.Text= _CurrentUser.Password;
            lblUserName.Text=_CurrentUser.UserName;  
            if(_CurrentUser.PersonInfo.ImagePath !=null)
            {
                pbProfilePicture.ImageLocation= _CurrentUser.PersonInfo.ImagePath;
            }
            else
            {
                pbProfilePicture.Image =Resources.uifaces_human_avatar__16_;

            }


            List<string> permissions = this._CurrentUser.UserPermissionsInfo.GetUserPermissionsList();
            if (permissions.Count == 0) 
            {
                permissions[0] = "no permissions";
            }

                listbPermissions.DataSource = permissions;
            if( _CurrentUser.IsActive)
            {
                lblActiveOrNot.Text = "Active";
                lblActiveOrNotDescription.Text = "The Account is active and can be used";
                btnActiveOrNot.FillColor = Color.Green;
                btnActiveOrNot.FillColor2= Color.DarkGreen;
            }
            else
            {
                lblActiveOrNot.Text = "Not Active";
                lblActiveOrNotDescription.Text = "The Account not active and it cannot be used";

                btnActiveOrNot.FillColor = Color.OrangeRed;
                btnActiveOrNot.FillColor2 = Color.DarkRed;
            }

        }


    }
}
