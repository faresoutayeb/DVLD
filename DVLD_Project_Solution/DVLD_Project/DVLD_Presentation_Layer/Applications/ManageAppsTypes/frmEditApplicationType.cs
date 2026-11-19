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
    public partial class frmEditApplicationType : Form
    {


        private int _ApplicationTypeId;
        private clsApplicationType _CurrentApplicationType;

        public frmEditApplicationType(int ApplicationTypeID)
        {

            InitializeComponent();

            this._ApplicationTypeId = ApplicationTypeID;
            clsValidation.OnValidationError += _WhenObjectIsNotValid;
        }



        private async Task _LoadApplicationInfoToControles(int ApplicationTypeID)
        {

            this._CurrentApplicationType = await clsApplicationType.FindApplicationTypeAsync((clsApplicationType.enApplicationType) ApplicationTypeID);
            if(this._CurrentApplicationType != null)
            {
                lblApplicationTypeID.Text = this._ApplicationTypeId.ToString();

                txtbApplicationTitle.Text= this._CurrentApplicationType.ApplicationTypeTitle.ToString();
                txtbFees.Text= this._CurrentApplicationType.ApplicationFees.ToString();
            }
            else
            {
                MessageBox.Show("Could not find application type with id = " + ApplicationTypeID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }


        }

        private async void LoadScreenEditApplicationType(object sender, EventArgs e)
        {
            await _LoadApplicationInfoToControles(_ApplicationTypeId);

        }

        private void txtbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsUtil.AllowOnlyNumberAndControlsToPress(sender,e);
        }


        private void _WhenObjectIsNotValid(object sender, clsValidationErrorEventArgs e)
        {
            MessageBox.Show($"Property Name {e.PropertyName} , Error Message {e.ErrorMessage}","object is not valid");
        }




        private async void button1_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some Field Not Are Not Correct ! put the mouse on the red icon to see the error");
                return;
            }

            this._CurrentApplicationType.ApplicationTypeTitle = txtbApplicationTitle.Text;
            this._CurrentApplicationType.ApplicationFees= Convert.ToSingle( txtbFees.Text);
            if(!clsValidation.IsValid(_CurrentApplicationType))
            {
                return;
            }
            if(await this._CurrentApplicationType.SaveAsync())
            {
                MessageBox.Show("Application Updated Successfully","",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Application Not Updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private async void EditApplicationType_Load(object sender, EventArgs e)
        {
            await _LoadApplicationInfoToControles(_ApplicationTypeId);

        }
    }
}
