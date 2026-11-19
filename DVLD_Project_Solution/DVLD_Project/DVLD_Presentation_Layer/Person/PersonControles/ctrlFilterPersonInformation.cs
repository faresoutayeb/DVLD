using DVLD_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Person.PersonControles
{
    public partial class ctrlFilterPersonInformation : UserControl
    {


        //----------------------- private local Variables ,----------------------------------- 

        private bool _EnableAddNewButton;
        private bool _EnableFilter;


        public enum enFilterBy { PersonID = 0, NationalNo = 1 }
        public enFilterBy _CurrentSelectedFilter = enFilterBy.PersonID;

        //----------------------- Public properties ,----------------------------------- 

        public int PersonId
        {
            get => ctrPersonInfoCard.PersonID; 
        }

        public string NationalNo
        {
            get => ctrPersonInfoCard.NationalNo;

        }

        public clsPerson SelectedPersonInfo
        { get => ctrPersonInfoCard.Person; }

        public bool EnableAddNewButton
        {
            get => _EnableAddNewButton;
            set
            {
                _EnableAddNewButton = value;
                btnAddNewPerson.Enabled = _EnableAddNewButton;
            }
        }

        public bool EnableFilter
        {
            get => _EnableFilter;
            set
            {
                _EnableFilter = value;
                gbFilterBy.Enabled = _EnableFilter;
            }
        }


        //----------------------- Constractors ,----------------------------------- 

        public ctrlFilterPersonInformation()
        {
            InitializeComponent();
        }


        //----------------------- Events  Definitions ,----------------------------------- 

        public event Action<int> OnPersonSelectedByPersonID;
        protected virtual void PersonSelectedByPersonID(int PersonID)
        {
            OnPersonSelectedByPersonID?.Invoke(PersonID);
        }

        public event Action<string> OnPersonSelectedByNationalNo;
        protected virtual void PersonSelectedByNationalNo(string  NationalNo)
        {
            OnPersonSelectedByNationalNo?.Invoke(NationalNo);
        }

        public event Action OnPersonSelectedNotFound;
        protected virtual void PersonSelectedNotFound()
        {
            OnPersonSelectedNotFound?.Invoke();
        }

        public event Action OnPersonSelectedFound;
        protected virtual void PersonSelectedFound()
        {
            OnPersonSelectedFound?.Invoke();
        }

        //---------------------- Local Functions -----------------------------
        public void FocusOnFilterTextBox()
        {
            txtbFilter.Focus();
        }


        //----------------------- Controls Events ----------------------------------- 


        private void ctrlCurrentPersonInfoControl_OnNoPersonFound()
        {
      

              PersonSelectedNotFound();

            
        }

        private void ctrlCurrentPersonInfoControl_OnPersonFound()
        {
    

                PersonSelectedFound();

            
        }


        private  void LoadInfo(object sender, int PersonID)
        {
            cbPersonFilter.SelectedIndex = (int)enFilterBy.PersonID ;
            txtbFilter.Text = NationalNo;
            btnSearch.PerformClick();

        }
        private  void LoadInfo(object sender, string NationalNo)
        {
            cbPersonFilter.SelectedIndex = (int)enFilterBy.PersonID;
            txtbFilter.Text = NationalNo;
            btnSearch.PerformClick();


        }

        private void pbAddNewPerson_Click(object sender, EventArgs e)
        {
            if (!clsGlobalUserInfo.CurrentLogInUser.UserPermissionsInfo.HasPermissionFor(clsUserPermissions.enPermissions.AddEditPerson))
            {

                clsGlobal.ShowAccessDeniedScreen();
                return;

            }
            frmAddEditPerson NewPerson = new frmAddEditPerson();
            NewPerson.OnDataBack += LoadInfo;
            NewPerson.ShowDialog();
        }


        public void LoadInfo(string NationalNo)
        {
            cbPersonFilter.SelectedIndex = (byte)enFilterBy.NationalNo;
            txtbFilter.Text = NationalNo.ToString();
            btnSearch.PerformClick();
        }
        public void LoadInfo(int PersonID)
        {
            cbPersonFilter.SelectedIndex = (byte)enFilterBy.PersonID;
            txtbFilter.Text = PersonID.ToString();

            btnSearch.PerformClick();


        }

        private async Task  _PerformLoadInfoByPersonID()
        {

            if (!string.IsNullOrEmpty(txtbFilter.Text))
            {
                if (int.TryParse(txtbFilter.Text.Trim(), out int PersonId))
                {

                  await  ctrPersonInfoCard.LoadPersonInfo(PersonId);

                    //here we going to check if the event has subscribers and teh filter is enable to raize the event because whebn the filter not enable you canot perform selecting person
                    if (ctrPersonInfoCard.IsPersonFounded)
                    {
                        // Raise the event with a parameter
                        PersonSelectedByPersonID(ctrPersonInfoCard.PersonID);

                    }
                }

            }

        }

        private async Task _PerformLoadInfoByNationalNo()
        {

            if (!string.IsNullOrEmpty(txtbFilter.Text.Trim()))
            {
               await ctrPersonInfoCard.LoadPersonInfo(txtbFilter.Text.Trim());

                if(ctrPersonInfoCard.IsPersonFounded)
                    PersonSelectedByNationalNo(ctrPersonInfoCard.NationalNo);

                
            }

        }

  

        private void txtbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar== (char)13)
            {
                btnSearch.PerformClick();
            }

            if (_CurrentSelectedFilter == (byte)enFilterBy.PersonID)
            {
                clsUtil.AllowOnlyNumberAndControlsToPress(sender, e);
            }
        }

        private void cbPersonFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CurrentSelectedFilter = (enFilterBy)cbPersonFilter.SelectedIndex;

        }
        private async void pbSearch_Click(object sender, EventArgs e)
        {           
            switch (_CurrentSelectedFilter)
            {
                case enFilterBy.PersonID:
                  await  _PerformLoadInfoByPersonID();
                    return;
                case enFilterBy.NationalNo:
                  await _PerformLoadInfoByNationalNo();
                    break;
                default:
                    break;
            }
        }

        private void ctrlFilterPersonInformation_Load(object sender, EventArgs e)
        {
            cbPersonFilter.SelectedIndex = (byte)enFilterBy.PersonID;
            btnSearch.Enabled = true;
            txtbFilter.Enabled = true;
            btnAddNewPerson.Enabled = true; 
            FocusOnFilterTextBox();
        }

    }
}
