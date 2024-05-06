using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Grifindo_Payroll_System
{
    public partial class managerLogin : KryptonForm
    {
        public managerLogin()
        {
            InitializeComponent();
            txtPassword.Text = "";
            txtPassword.PasswordChar = '*';
        }

        // Sql Data Connection
        private SqlConnection Connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False");
        // Sql Data Connection

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from MangerTbl where mngNic='" + txtUserName.Text + "'AND mngPass='" + txtPassword.Text + "'", Connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Connection.Close();
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Successfull");
                this.Hide();
                managerHome mngHome = new managerHome();
                mngHome.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Error");
                txtUserName.Text = "";
                txtPassword.Text = "";
            }
        }

        private void showPass_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0'; // Reveal password
                showPass.Text = "Hide Password";
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Mask password
                showPass.Text = "Show Password";
            }
            txtPassword.Focus(); // Move focus to the password field
        }

        private void LnkClearData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }
    }
}
