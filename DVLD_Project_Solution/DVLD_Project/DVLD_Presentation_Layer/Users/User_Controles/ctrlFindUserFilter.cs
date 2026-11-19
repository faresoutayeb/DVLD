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

namespace DVLD_Presentation_Layer.Users.User_Controles
{
    public partial class ctrlFindUserFilter : UserControl
    {
        public ctrlFindUserFilter()
        {
            InitializeComponent();
        }

        private enum enFilterBy { UserID, UserName }
        private enFilterBy _CurrentSearchByMethod=enFilterBy.UserID;

        public event Action<int> OnSearchedForUserByUserID;
        protected virtual void SearchForUserByUserID(int UserID)
        {
            OnSearchedForUserByUserID?.Invoke(UserID);
        }

        public event Action<string> OnSearchedForUserByUserName;
        protected virtual void SearchForUserByUserName(string UserName)
        {
            OnSearchedForUserByUserName?.Invoke(UserName);
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex== (byte)enFilterBy.UserID)
            {
                _CurrentSearchByMethod=enFilterBy.UserID;
            }
            else
            {
                _CurrentSearchByMethod = enFilterBy.UserName;

            }
            

        }



        private void SearchButton_Click(object sender, EventArgs e)
        {
            if(_CurrentSearchByMethod==enFilterBy.UserID)
            {
                int UserID;
                if(int.TryParse(txtbSearchBy.Text,out int ParsedUserID))
                {
                    UserID = ParsedUserID; 
                    SearchForUserByUserID(UserID);
                }                
            }
            else
            {
                SearchForUserByUserName(txtbSearchBy.Text);
            }


        }

        private void txtbSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
            if (_CurrentSearchByMethod == enFilterBy.UserID)
            {
                clsUtil.AllowOnlyNumberAndControlsToPress(sender, e);
            }

        }

        public void LoadInfoToControls(int UserID)
        {
            comboBox1.SelectedIndex = (byte)enFilterBy.UserID;
            txtbSearchBy.Text=UserID.ToString();
            if(OnSearchedForUserByUserID != null)
            {
                SearchForUserByUserID(UserID);


            }


        }


        public void LoadInfoToControls(string UserName)
        {
            comboBox1.SelectedIndex = (byte)enFilterBy.UserName;
            txtbSearchBy.Text = UserName;
            if(OnSearchedForUserByUserName != null)
            {
                SearchForUserByUserName(UserName);


            }

        }

        private void txtbSearchBy_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
