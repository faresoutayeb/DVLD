using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace DVLD_Presentation_Layer.Users.User_Screens
{
    public  partial class frmAddEditUser
    {

        private void _WhenPersonNotFound()
        {
            MessageBox.Show("Person Not Found", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void _WhenUserInfoUpdated(int UserID)
        {
            MessageBox.Show($"User with Id {UserID} info updated successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _WhenUserInfoNotUpdated()
        {
            MessageBox.Show($"User with Id  info not  updated", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void _WhenNewUserAdded(int NewUserID)
        {
            MessageBox.Show($"New User Added With id = {NewUserID}", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void _WhenNewUserNotAdded()
        {
            MessageBox.Show($"New User Not Added ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //--------------------  Initilize Function To fire-------------------------------- 

        private void _WhenUserLocked(int lockingID,int UserID)
        {
            MessageBox.Show($"User With id = {UserID} was locked with locking id = {lockingID}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _WhenUserNotLocked( int UserID)
        {
            MessageBox.Show($"User With id = {UserID} not locked", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void _WhenUserUnLocked(int UserID)
        {
            MessageBox.Show($"User With id = {UserID} was Unlocked", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void _WhenUserNotUnLocked(int UserID)
        {
            MessageBox.Show($"User With id = {UserID} was Not Unlocked", "Unlocking Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
