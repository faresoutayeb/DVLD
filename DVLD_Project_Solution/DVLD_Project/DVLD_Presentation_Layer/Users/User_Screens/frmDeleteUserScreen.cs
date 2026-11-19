using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Users.User_Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Users.UserScreens
{
    public partial class frmDeleteUserScreen : Form
    {

        private int _UserId;
        private clsUser _CurrentUser;

        public frmDeleteUserScreen(int UserIdToDelete)
        {

            InitializeComponent();
            _UserId=UserIdToDelete;


        }
        public delegate void DataBackEventHandler(object sender, int UserID);

        // Declare an event using the delegate
        public event DataBackEventHandler OnDataBack;


        private async void DeleteUserScreen_Load(object sender, EventArgs e)
        {
            _CurrentUser = await clsUser.FindByUserIDAsync(_UserId);
            if (_CurrentUser != null)
            {
               await ctrlSmallUserInfoCard1.LoadInfo(_CurrentUser.UserID);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Delete This User", "Delete User", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                if (await clsUser.DeleteUserAsync(_UserId))
                {
                    ctrlSmallUserInfoCard1.LoadDefaultInfo();
                    MessageBox.Show("User Deleted Succesfully");
                    if(OnDataBack != null)
                    {
                        OnDataBack.Invoke(this, _UserId);
                    }

                }
                else
                {
                    MessageBox.Show("User Not Deleted");

                }

            }
        }
    }
}
