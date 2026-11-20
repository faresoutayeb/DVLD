using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Drawing.Drawing2D;
using DVLD_Presentation_Layer.Properties;


namespace DVLD_Presentation_Layer
{
    public partial class frmManagePeopleScreen : Form
    {

        public frmManagePeopleScreen()
        {
            InitializeComponent();
            InitilizeLocalEvents();
        }

        //---------------------------- Local Variables Definitions -------------------------------------------------

        private static DataTable _dtAllPeople ;
        private static DataTable _dtPeople;
        //only select the columns that you want to show in the grid
        private enum enFilterBy
        {
            None,
            PersonID,
            NationalNo,
            FirstName,
            LastName,
            CountryName,
            GendorCaption,
            Phone,
            Email,
        }
        enFilterBy _CurrentSelectedFilter = enFilterBy.None;

        enum enGenderFilter { All=0,Male=1,Female=2}
        enGenderFilter _CurrentGenderFilter = enGenderFilter.All;





        //---------------------------- Local Events Definitions -------------------------------------------------
        private void LoadPeopleImageToDataGrid()
        {
           




                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();

                imageColumn.Name = "P.Image";
                imageColumn.HeaderText = "";
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;


                dgvPeople.Columns.Insert(0, imageColumn);


                dgvPeople.Columns[0].Width = 50;

                foreach (DataGridViewRow row in dgvPeople.Rows)
                {
                    if (row.Cells["ImagePath"].Value != DBNull.Value)
                    {
                        string imagePath = row.Cells["ImagePath"].Value.ToString();

                        if (File.Exists(imagePath))
                        {
                            row.Cells["P.Image"].Value = MakeCircularImage(Image.FromFile(imagePath));
                        }
                        else
                        {
                           row.Cells["P.Image"].Value = MakeCircularImage(Resources.user);

                        }
                    }
                    else
                    {
                         row.Cells["P.Image"].Value = MakeCircularImage(Resources.user);

                    }
                }
        }

        private void LoadPeopleImageToDataGrid(DataView CurrentDataView)
        {





            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();

            imageColumn.Name = "P.Image";
            imageColumn.HeaderText = "";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;


            dgvPeople.Columns.Insert(0, imageColumn);


            dgvPeople.Columns[0].Width = 50;

            foreach (DataGridViewRow row in dgvPeople.Rows)
            {
                if (row.Cells["ImagePath"].Value != DBNull.Value)
                {
                    string imagePath = row.Cells["ImagePath"].Value.ToString();

                    if (File.Exists(imagePath))
                    {
                        row.Cells["P.Image"].Value = MakeCircularImage(Image.FromFile(imagePath));
                    }
                    else
                    {
                        row.Cells["P.Image"].Value = MakeCircularImage(Resources.user);

                    }
                }
                else
                {
                    row.Cells["P.Image"].Value = MakeCircularImage(Resources.user);

                }
            }
        }


        private Image MakeCircularImage(Image image)
        {
            Bitmap bitmap = new Bitmap(image.Width, image.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, image.Width, image.Height);
                    g.SetClip(path);
                    g.DrawImage(image, 0, 0);
                }

            return bitmap;
        }


        public event Action<int> OnPersonDeleted;
        protected virtual void PersonDeleted(int PersonID)
        {
            OnPersonDeleted?.Invoke(PersonID);
        }

        public event Action<int> OnPersonNotDeleted;
        protected virtual void PersonNotDeleted(int PersonID)
        {
            OnPersonNotDeleted?.Invoke(PersonID);
        }


        //---------------------------- Controls Events-------------------------------------------------
        private async Task _HardRefreshPeoplList()
        {
            _dtAllPeople= await Task.Run(() => clsPerson.GetAllPeopleAsync());

            _dtPeople = _dtAllPeople.DefaultView.ToTable(
                false, "PersonID", "NationalNo", "FirstName", "LastName",
                "Gendor", "DateOfBirth", "CountryName", "Phone", "Email", "ImagePath");

            dgvPeople.DataSource = _dtPeople.DefaultView;
            //LoadPeopleImageToDataGrid();
            SetPeopleTableColumnsStructure();
            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();

            ctrlDataGridPagesMoving1.btnFirst.PerformClick();


        }

        private void SetControlsVisibility()
        {
            txtFilterValue.Visible = (_CurrentSelectedFilter != enFilterBy.None && _CurrentSelectedFilter != enFilterBy.GendorCaption);
            cbGender.Visible = (_CurrentSelectedFilter == enFilterBy.GendorCaption);
            cbGender.SelectedIndex = 0;
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private string GetColumnNameDependOnSelectedFilter()
        {
            //Map Selected Filter to real Column name 

            switch ((enFilterBy)cbFilterBy.SelectedIndex)
            {
                case enFilterBy.PersonID:
                    return "PersonID";
                case enFilterBy.NationalNo:
                    return "NationalNo";
                case enFilterBy.FirstName:
                    return "FirstName";
                case enFilterBy.LastName:
                    return "LastName";
                case enFilterBy.CountryName:
                    return "CountryName";
                case enFilterBy.GendorCaption:
                    return "GendorCaption";
                case enFilterBy.Phone:
                    return "Phone";
                case enFilterBy.Email:
                    return "Email";
                default:
                    return "None";
            }

        }

        private void _ResetPeopleTableFilter()
       {
            _dtPeople.DefaultView.RowFilter = "";
            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblRecordsCount.Text = _dtPeople.DefaultView.Count.ToString();

        }

        private void SetPeopleTableColumnsStructure()
        {

            if (dgvPeople.Rows.Count > 0)
            {

                
                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 60;

                dgvPeople.Columns[1].HeaderText = "National No.";
                dgvPeople.Columns[1].Width = 80;


                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 100;

                //dgvPeople.Columns[4].HeaderText = "Second Name";
                //dgvPeople.Columns[4].Width = 100;


                //dgvPeople.Columns[5].HeaderText = "Third Name";
                //dgvPeople.Columns[5].Width = 100;

                dgvPeople.Columns[3].HeaderText = "Last Name";
                dgvPeople.Columns[3].Width = 100;

                dgvPeople.Columns[4].HeaderText = "Gendor";
                dgvPeople.Columns[4].Width = 50;

                dgvPeople.Columns[5].HeaderText = "Date Of Birth";
                dgvPeople.Columns[5].Width = 100;

                dgvPeople.Columns[6].HeaderText = "Nationality";
                dgvPeople.Columns[6].Width = 120;


                dgvPeople.Columns[7].HeaderText = "Phone";
                dgvPeople.Columns[7].Width = 100;


                dgvPeople.Columns[8].HeaderText = "Email";
                dgvPeople.Columns[8].Width = 170;
                //dgvPeople.Columns[10].HeaderText = "";
                //dgvPeople.Columns[10].Width = 0;
                dgvPeople.Columns[9].Visible = false;

            }
        }


        private void SetPeopleTableColumnsStructureWithImage()
        {

            if (dgvPeople.Rows.Count > 0)
            {
                dgvPeople.Columns[0].HeaderText = "";
                dgvPeople.Columns[0].Width = 30;

                dgvPeople.Columns[1].HeaderText = "Person ID";
                dgvPeople.Columns[1].Width = 60;

                dgvPeople.Columns[2].HeaderText = "National No.";
                dgvPeople.Columns[2].Width = 80;


                dgvPeople.Columns[3].HeaderText = "First Name";
                dgvPeople.Columns[3].Width = 100;

                //dgvPeople.Columns[4].HeaderText = "Second Name";
                //dgvPeople.Columns[4].Width = 100;


                //dgvPeople.Columns[5].HeaderText = "Third Name";
                //dgvPeople.Columns[5].Width = 100;

                dgvPeople.Columns[4].HeaderText = "Last Name";
                dgvPeople.Columns[4].Width = 100;

                dgvPeople.Columns[5].HeaderText = "Gendor";
                dgvPeople.Columns[5].Width = 50;

                dgvPeople.Columns[6].HeaderText = "Date Of Birth";
                dgvPeople.Columns[6].Width = 100;

                dgvPeople.Columns[7].HeaderText = "Nationality";
                dgvPeople.Columns[7].Width = 120;


                dgvPeople.Columns[8].HeaderText = "Phone";
                dgvPeople.Columns[8].Width = 100;


                dgvPeople.Columns[9].HeaderText = "Email";
                dgvPeople.Columns[9].Width = 170;
                //dgvPeople.Columns[10].HeaderText = "";
                //dgvPeople.Columns[10].Width = 0;
                dgvPeople.Columns[10].Visible = false;

            }
        }

        private async void LoadAndSetDataTableStructure()
        {
            await _HardRefreshPeoplList();

        }

        private async void _WhenPersonDeleted(int DeletedPersonID)
        {
            MessageBox.Show($"Person with id = {DeletedPersonID} Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await _HardRefreshPeoplList();
 
        }

        private void _WhenPersonNotDeleted(int PersonID)
        {
            MessageBox.Show($"Person  with Id = {PersonID} was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void InitilizeLocalEvents()
        {
            OnPersonDeleted += _WhenPersonDeleted;
            OnPersonNotDeleted += _WhenPersonNotDeleted;
        }

        internal async Task _PerformDeleteOperation(int PersonID)
        {

            if (clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.DeletePerson))
            {

                //Perform Delele and refresh
                if (await clsPerson.DeletePersonAsync(PersonID))
                {
               
                        PersonDeleted(PersonID);
                    
                }

                else
                {
                    
                        PersonNotDeleted(PersonID);
                    
                }

            }
        }
        private async void frmListPeople_Load(object sender, EventArgs e)
        {
           await _HardRefreshPeoplList();
            LoadAndSetDataTableStructure();

        }



        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            SetControlsVisibility();

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmPersonInformationScreen frm = new frmPersonInformationScreen((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.AddEditPerson))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmAddEditPerson frm = new frmAddEditPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            await _HardRefreshPeoplList();

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }


        private void txtFilterValue_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (_CurrentSelectedFilter == enFilterBy.PersonID)
            {
                clsUtil.AllowOnlyNumberAndControlsToPress(sender, e);
            }
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.AddEditPerson))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmAddEditPerson frm1 = new frmAddEditPerson();
            frm1.ShowDialog();
            await _HardRefreshPeoplList();
        }

        private async void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            if (
                MessageBox.Show($"Are you sure you want to delete Person {PersonID} ", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK
                )
               await _PerformDeleteOperation(PersonID);
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonInformationScreen frm = new frmPersonInformationScreen((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private async void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.AddEditPerson))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmAddEditPerson frm1 = new frmAddEditPerson();
            frm1.ShowDialog();
           await _HardRefreshPeoplList();
        }

        private async void editPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.AddEditPerson))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmAddEditPerson frm1 = new frmAddEditPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm1.ShowDialog();
            await _HardRefreshPeoplList();
        }

        private void dgvPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmPersonInformationScreen frm = new frmPersonInformationScreen((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _CurrentSelectedFilter=(enFilterBy) cbFilterBy.SelectedIndex;
            SetControlsVisibility();

        }

        private async void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.AddEditPerson))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmAddEditPerson frm1 = new frmAddEditPerson();
            frm1.ShowDialog();
            await _HardRefreshPeoplList();
        }

        private async void ManagePeopleScreen_Load(object sender, EventArgs e)
        {
            LoadAndSetDataTableStructure();
           await ctrlTotalFemales1.LoadInfo();
           await ctrlTotallMales1.LoadInfo();
           await ctrlTotalPeopleRegisteredToday1.LoadInfo();
           await ctrlTotalPeopleRegistredThisMonth1.LoadInfo();
           await ctrlTotalPeopleRegistredThisYear1.LoadInfo();
           await ctrlTotalPersons1.LoadInfo();
            ctrlRecentlyAddedPeople1.LoadInfo();
            //ctrlDataGridPagesMoving1.btnFirst.PerformClick();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            _ResetPeopleTableFilter();

        }

        private void dgvPeople_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtFilterValue_TextChanged_1(object sender, EventArgs e)
        {
            enFilterBy ColumnToFilterBy = (enFilterBy)cbFilterBy.SelectedIndex;
            string FilterColumn = GetColumnNameDependOnSelectedFilter();

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || ColumnToFilterBy == enFilterBy.None)
            {
                _ResetPeopleTableFilter();
                return;
            }
            if (ColumnToFilterBy == enFilterBy.PersonID)
            {
                //in this case we deal with integer not string.

                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());

            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            }


            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblRecordsCount.Text = _dtPeople.DefaultView.Count.ToString();
        }

        private async void guna2GradientButton3_Click(object sender, EventArgs e)
        {
           await _HardRefreshPeoplList();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentGenderFilter = (enGenderFilter)cbGender.SelectedIndex;
            string FilterColumn = GetColumnNameDependOnSelectedFilter();

            if (_CurrentGenderFilter==enGenderFilter.All)
            {
                _ResetPeopleTableFilter();
                return;
            }
            if (_CurrentGenderFilter == enGenderFilter.Male)
            {

                _dtPeople.DefaultView.RowFilter = string.Format($"[Gendor] like 'Male%'");

            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format($"[Gendor] like 'Female%'");

            }
            ctrlDataGridPagesMoving1.CurrentPage = 1;
            ctrlDataGridPagesMoving1.btnFirst.PerformClick();

            lblRecordsCount.Text = _dtPeople.DefaultView.Count.ToString();

        }



        private void ctrlDataGridPagesMoving1_OnButtonClicked_1()
        {
            dgvPeople.DataSource =  ctrlDataGridPagesMoving1.GetUpdateTable(_dtPeople.DefaultView);
            if ( _CurrentSelectedFilter != enFilterBy.None)
            {
                txtFilterValue.Focus();
            }

        }
    }
}
