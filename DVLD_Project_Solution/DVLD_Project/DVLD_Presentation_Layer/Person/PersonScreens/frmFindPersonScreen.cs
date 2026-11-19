using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Person.PersonScreens.Find_Person
{
    public partial class frmFindPersonScreen : Form
    {
        public frmFindPersonScreen()
        {
            InitializeComponent();
        }


        public delegate void DataBackEventHandler(object sender, int PersonID );
        protected event  DataBackEventHandler DataBack;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            DataBack?.Invoke(this, ctrlFilterPersonInformation1.PersonId);
        }
    }
}
