using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Users.UserControles
{
    public partial class ctrlUserLoginInfo1 : UserControl
    {
        public ctrlUserLoginInfo1()
        {
            InitializeComponent();
        }

        private int _UserID = -1;
        private clsUser _User;

        public int UserID
        {
            get { return _UserID; }
        }
        public void LoadDefaultValuesToControls()
        {
                lblUserID.Text = "";
                lblUserName.Text = "";
                lblIsActive.Text = "";
            lblIsLocked.Text = "";
                ctrlPersonInfo1.LoadDefaultControlsValue();
                _User = null;
                _UserID=-1;
        }

        public event Action OnUserNotFound;
        protected virtual void UserNotFound()
        {
            OnUserNotFound?.Invoke();
        }

        public async Task LoadUserInfo(int UsersId)
        {
            _UserID= UsersId;
            _User = await clsUser.FindByUserIDAsync(UsersId);
            if(_User != null)
            {

               await ctrlPersonInfo1.LoadPersonInfo(_User.PersonID);
                lblUserID.Text= _User.UserID.ToString();
                lblUserName.Text= _User.UserName.ToString();
                lblIsActive.Text = (_User.IsActive) ? "Yes" : "No";
                lblIsLocked.Text = (_User.IsLock) ? "Yes" : "No";
            }
            else
            {
                LoadDefaultValuesToControls();
                if(OnUserNotFound != null)
                {
                    UserNotFound();
                }
                return;
            }


        }


    }
}
