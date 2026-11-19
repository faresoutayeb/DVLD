using DVLD.Classes;
using DVLD_Bussiness_Layer;
using DVLD_Bussiness_Layer.CustomAttributes;
using DVLD_Bussiness_Layer.GlobalClasses;
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
    public partial class UpdateTestTypesScreen : Form
    {
        private clsTestType.enTestType _TestTypeId=clsTestType.enTestType.VisionTest;
        private clsTestType _CurrentTestType;

        public UpdateTestTypesScreen(clsTestType.enTestType TestTypeId)
        {
            InitializeComponent();
            this._TestTypeId = TestTypeId;
            clsValidation.OnValidationError += _WhenObjectIsNotValid;

        }

        private async Task _LoadTestInfoToControles(clsTestType.enTestType TestType)
        {
            _CurrentTestType = await clsTestType.FindTestTypeAsync((clsTestType.enTestType) TestType);
            if (_CurrentTestType != null)
            {
                lblTestTypeID.Text = _CurrentTestType.TestTypeID.ToString();
                txtbTypeTypeTitle.Text = _CurrentTestType.TestTypeTitle;
                txtbTestDescription.Text = _CurrentTestType.TestTypeDescription;
                txtbTestTypeFees.Text= _CurrentTestType.TestTypeFees.ToString();

            }
            else

            {
                MessageBox.Show("Could not find Test Type with id = " + _TestTypeId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }


        }


        private void _WhenObjectIsNotValid(object sender, clsValidationErrorEventArgs e)
        {
            MessageBox.Show($"Property Name {e.PropertyName} , Error Message {e.ErrorMessage}", "object is not valid");
        }


        private async void UpdateTestTypesScreen_Load(object sender, EventArgs e)
        {
            await _LoadTestInfoToControles(_TestTypeId);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some field not corret put the  mouse on teh red icon to see the error ", "Validation Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            _CurrentTestType.TestTypeTitle = txtbTypeTypeTitle.Text;
            _CurrentTestType.TestTypeDescription = txtbTestDescription.Text;
                _CurrentTestType.TestTypeFees = Convert.ToSingle(txtbTestTypeFees.Text);
            if(!clsValidation.IsValid(_CurrentTestType))
            {
                return;
            }
            if (await _CurrentTestType.SaveAsync())
            {
                MessageBox.Show("Test Type Updated Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Test Type Not Updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void txtbTypeName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbTypeTypeTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbTypeTypeTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtbTypeTypeTitle, null);
            }
            ;
        }

        private void txtbTestDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbTestDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbTestDescription, "Description cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtbTestDescription, null);
            }
            ;
        }

        private void txtbTestTypeFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbTestTypeFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbTestTypeFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtbTestTypeFees, null);

            }
            ;


            if (!clsValidation.IsNumber(txtbTestTypeFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbTestTypeFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtbTestTypeFees, null);
            }
            ;
        }


        private void txtbTestTypeFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtil.AllowOnlyNumberAndControlsToPress(sender, e);

        }
    }
}
