using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Global_Controls
{
    public partial class ctrlActualDateTime : UserControl
    {
        public ctrlActualDateTime()
        {
            InitializeComponent();
            UpdateDateTime();
        }



        private void UpdateDateTime()
        {
            lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }



        private void timer1_Tick_1(object sender, EventArgs e)
        {
            UpdateDateTime();

        }
    }
}
