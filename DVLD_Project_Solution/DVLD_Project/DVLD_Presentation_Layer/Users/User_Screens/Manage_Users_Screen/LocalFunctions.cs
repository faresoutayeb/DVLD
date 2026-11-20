using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Presentation_Layer.Users.User_Screens
{
    public partial class frmManageUsersScreen
    {
        private void _RefreshUsersTableFilter()
        {

            _dtAllUsers.DefaultView.RowFilter = "";
            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblTotalUsers.Text = _dtAllUsers.DefaultView.Count.ToString();
        }
        private void PerformFiltringDataWhenIsActiveFilterSelected()
        {

            string FilterColumn = "IsActive";
            string FilterValue = _CurrentFilterValue();



            if (_CurrentSelectedByActiveOrNot == enFilterByActiveOrNot.All)
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblTotalUsers.Text = _dtAllUsers.DefaultView.Count.ToString();
        }

        private async Task _LoadUsersInfoToDataGrid()
        {
            _dtAllUsers = await Task.Run(() => clsUser.GetUserScreenUsersInfoAsync());

            dgvUsers.DataSource = _dtAllUsers;
            cbFilterBy.SelectedIndex = 0;
            lblTotalUsers.Text = dgvUsers.Rows.Count.ToString();


            


        }

        private async Task HardRefresh()
        {
          await  _LoadUsersInfoToDataGrid();
            _RefreshUsersTableFilter();
        }

        private void _SetUserTableColumns()
        {

            dgvUsers.Columns[0].HeaderText = "User ID";
            dgvUsers.Columns[0].Width = 110;
            dgvUsers.Columns[1].HeaderText = "Person ID";
            dgvUsers.Columns[1].Width = 120;
            dgvUsers.Columns[2].HeaderText = "Full Name";
            dgvUsers.Columns[2].Width = 350;
            dgvUsers.Columns[3].HeaderText = "UserName";
            dgvUsers.Columns[3].Width = 120;
            dgvUsers.Columns[4].HeaderText = "Is Active";
            dgvUsers.Columns[4].Width = 120;


        }

        private void SetControlsVisibilityWhenSelectingFilterByChanged()
        {
            if (_CurrentSelectedFilter == enFilterBy.IsActive)
            {
                txtbFilterBy.Visible = false;
                cbFilterByActive.Visible = true;
                cbFilterByActive.Focus();
                cbFilterByActive.SelectedIndex = 0;
            }

            else

            {

                cbFilterByActive.Visible = false;

                if (_CurrentSelectedFilter==enFilterBy.None)
                {
                    txtbFilterBy.Enabled = false;
                }
                else
                {
                    txtbFilterBy.Visible = true;

                    txtbFilterBy.Text = "";
                    txtbFilterBy.Focus();
                }


            }


        }

        private string _CurrentSelectedColumnName()
        {

            switch (_CurrentSelectedFilter)
            {

                case enFilterBy.UserId:
                    return "UserID";
                case enFilterBy.PersonId:
                    return "PersonID";
                case enFilterBy.FullName:
                    return "FullName";
                case enFilterBy.UsersName:
                    return "UserName";
                default:
                    return "None";

            }
        }

        private void PerformDataFiltring()
        {
            string FilterColumn = _CurrentSelectedColumnName();
            //Map Selected Filter to real Column name 
            string TextToFilterBy= txtbFilterBy.Text.Trim();
            //Reset the filters in case nothing selected or filter value conains nothing.
            if (TextToFilterBy == "" || _CurrentSelectedFilter == enFilterBy.None)
            {
                _RefreshUsersTableFilter();
                return;
            }


            if (_CurrentSelectedFilter != enFilterBy.FullName && _CurrentSelectedFilter != enFilterBy.UsersName)
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, TextToFilterBy);
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, TextToFilterBy);

            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblTotalUsers.Text = _dtAllUsers.DefaultView.Count.ToString();
        }

        private string _CurrentFilterValue()
        {

            switch (_CurrentSelectedByActiveOrNot)
            {
                case enFilterByActiveOrNot.Active:
                    return "1";
                case enFilterByActiveOrNot.Inactive:
                    return "0";
                default:
                    return "All";
            }

        }



    }
}
