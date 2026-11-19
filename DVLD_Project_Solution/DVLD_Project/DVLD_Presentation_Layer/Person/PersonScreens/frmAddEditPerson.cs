using DVLD_Bussiness_Layer;
using DVLD_Presentation_Layer.Person.PersonControles;
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

namespace DVLD_Presentation_Layer
{
    public partial class frmAddEditPerson : Form
    {       
        enum enMode { AddNewPerson,UpdatePerson}
        enMode _Mode=enMode.AddNewPerson;
        public frmAddEditPerson()
        {

            InitializeComponent();
            _Mode=enMode.AddNewPerson;

        }

        public frmAddEditPerson(int PersonID)
        {

            InitializeComponent();
            _Mode = enMode.UpdatePerson;

            _PersonID = PersonID;
        }


        // ------------------------------------initilize varibles and events ------------------------------------- 

        private int _PersonID=-1;

        //public event Action OnAddEditPersonFormClose;
        //protected virtual void AddEditPersonFormClose()
        //{
        //    OnAddEditPersonFormClose?.Invoke();
        //}

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler OnDataBack;

        protected void SendDataBack(object sender, int PersonID)
        {
            OnDataBack?.Invoke(sender, PersonID);
        }


        // ------------------------------------Function To Call When Events fired ------------------------------------- 

        private void _WhenNewPersonAdded(int newPersonID)
        {

            MessageBox.Show($"New Person Added Succesfully with id = {newPersonID} "," ",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void _WhenNewPersonNotAdded()
        {

            MessageBox.Show($"New Person Not Added  ", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void _WhenPersonInfoUpdated()
        {

            MessageBox.Show($"Person with id {_PersonID} Info Updated ", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void _WhenPersonInfoNotUpdated()
        {

            MessageBox.Show($"Person Info Not Updated  ", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void _WhenPersonNotFound()
        {

            MessageBox.Show($"Person Not Found  ", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }




        public void LoadDefaultPersonInfoToCurrentForm() 
        {

            if (ctrlEditPersonInfo1._Mode == ctrlEditPersonInfo.enMode.eAddNewPerson)
            {
                lblTitle.Text = "Add New Person";
                pbAddEditScreen.Image = Resources.person_man;
            }
            else
            {
                lblTitle.Text = "Update Person";
                lblPersonID.Text = _PersonID.ToString();
                pbAddEditScreen.Image = Resources.UpdatePersonImage;
            }

        }


        // ------------------------------------ Controls events  ------------------------------------- 


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
           SendDataBack(this, ctrlEditPersonInfo1.PersonID);

        }

        private void ctrlEditPersonInfo1_OnPersonUpdated_1()
        {
            _WhenPersonInfoNotUpdated();

        }

        private void ctrlEditPersonInfo1_OnPersonUpdated(int PersonID)
        {
            _PersonID = PersonID;
            lblPersonID.Text = _PersonID.ToString();
            _WhenPersonInfoUpdated();
        }


        private void ctrlEditPersonInfo1_OnNoPersonFound_1()
        {
            _WhenPersonNotFound();

        }


        private void ctrlEditPersonInfo1_OnNewPersonAdded(int NewPersonID)
        {
            _PersonID = NewPersonID;
            lblPersonID.Text = _PersonID.ToString();

            _WhenNewPersonAdded(_PersonID);
        }

        private void ctrlEditPersonInfo1_DataBack_1(object sender, int PersonID)
        {
            LoadDefaultPersonInfoToCurrentForm();
            SendDataBack(sender, PersonID);
        }

        private void Add_EditPersonScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                ctrlEditPersonInfo1.btnSave.Focus();
            }

        }

        private void ctrlEditPersonInfo1_OnPersonObjectNotValid()
        {
            MessageBox.Show("Person object not valid");
        }



        private async void frmAddEditPerson_Load(object sender, EventArgs e)
        {
                LoadDefaultPersonInfoToCurrentForm();

            if(_Mode==enMode.AddNewPerson)
            {

                ctrlEditPersonInfo1.LoadDefaultValues();
                this.KeyPreview = true;
            }
            else
            {
               await ctrlEditPersonInfo1.LoadPersonInfoToControl(_PersonID);
                _PersonID = ctrlEditPersonInfo1.PersonID;
                lblPersonID.Text = _PersonID.ToString();    
                this.KeyPreview = true;
            }
        }

        private void ctrlEditPersonInfo1_OnNewPersonNotAdded()
        {
            MessageBox.Show($"New Person added succesfully with id {_PersonID} ", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
