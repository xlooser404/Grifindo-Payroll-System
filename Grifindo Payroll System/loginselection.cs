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
    public partial class loginselection : KryptonForm
    {
        public loginselection()
        {
            InitializeComponent();
        }

        private void picAdmin_Click(object sender, EventArgs e)
        {
            adminLogin adminLogin = new adminLogin();
            adminLogin.Show();
            this.Hide();
        }

        private void picManager_Click(object sender, EventArgs e)
        {
            managerLogin managerLogin = new managerLogin();
            managerLogin.Show();
            this.Hide();
        }

        private void closePIC_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
