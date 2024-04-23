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

namespace Grifindo_Payroll_System.adminPages
{
    public partial class Salary : KryptonForm
    {
        public Salary()
        {
            InitializeComponent();
        }

        // Sql Data Connection
        private SqlConnection Connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False");
        // Sql Data Connection

        // Display Attendence Details
        private void AttendenceList()
        {
            string query = "SELECT empID, empName, dayPresent, dayAbsence, dayExcuse, period, empNic, empContact FROM AttendenceTbl";
            using (SqlConnection connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False"))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    SalaryDGV.DataSource = dataTable;
                    SalaryDGV.Refresh();
                }
            }

        }

        // Search Function
        private void TextboxFilter()
        {
            Connection.Open();
            string query = " SELECT * from AttendenceTbl where empNic ='" + txtSearch.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            SalaryDGV.DataSource = dataTable;
            SalaryDGV.Refresh();
            Connection.Close();

        }

        // Clear Function 
        private void Clear_Data()
        {
            txtName.Text = "";
            txtAbsence.Text = "";
            txtPresent.Text = "";
            txtExcuses.Text = "";
        }

        // Get Employee ID to Attendence form
        private void getEmployeeID()
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand("Select * from EmployeeTbl", Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("empID", typeof(int));
            dataTable.Load(reader);
            cbEmpID.ValueMember = "empID";
            cbEmpID.DataSource = dataTable;
            Connection.Close();
        }

        // Get Employee Names, contact, Nic using empID
        private void getEmployeedetails()
        {
            Connection.Open();
            String Query = "Select * from EmployeeTbl where empID" + cbEmpID.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(Query, Connection);
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                txtName.Text = dataRow["empName"].ToString();
                txtNic.Text = dataRow["empNic"].ToString();
                txtContact.Text = dataRow["empContact"].ToString();
            }
        }

        // cbEmpID combo box ID selection 
        private void cbEmpID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getEmployeedetails();
        }
    }
}
