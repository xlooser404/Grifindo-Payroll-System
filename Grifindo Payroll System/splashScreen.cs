using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Payroll_System
{
    public partial class splashScreen : KryptonForm
    {
        public splashScreen()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = true;
            ProgBar.Increment(2);
            if (ProgBar.Value == 100)
            {
                Timer.Enabled = false;
                loginselection loginSelection = new loginselection();
                loginSelection.Show();
                this.Hide();
            }
        }
    }
}
