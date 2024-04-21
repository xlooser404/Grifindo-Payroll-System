using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Grifindo_Payroll_System.Pages
{
    public partial class Attendance : KryptonForm
    {
        public Attendance()
        {
            InitializeComponent();
            AttendenceList();
            getEmployeeID();
        }

        // Sql Data Connection
        private SqlConnection Connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False");
        // Sql Data Connection

        //Display Attendence Details
        private void AttendenceList()
        {
            string query = "SELECT empID, empName, dayPresent, dayAbsence, dayExcuse, period, empNic, empContact FROM AttendenceTbl";
            using (SqlConnection connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False"))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    AttendenceDGV.DataSource = dataTable;
                    AttendenceDGV.Refresh();
                }
            }

        }

        //Search Function
        private void TextboxFilter()
        {
            Connection.Open();
            string query = " SELECT * from AttendenceTbl where empNic ='" + txtSearch.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            AttendenceDGV.DataSource = dataTable;
            AttendenceDGV.Refresh();
            Connection.Close();

        }

        //Clear Function 
        private void Clear_Data()
        {
            txtName.Text = "";
            txtAbsence.Text = "";
            txtPresent.Text = "";
            txtExcuses.Text = "";
        }

        //Get Employee ID to Attendence form
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

        // Get Employee Names using ID Function 
        private void getEmployeeNames()
        {
            Connection.Open();
            String Query = "Select * from EmployeeTbl where empID"
        }

        // Save Button Click Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate user input to ensure all fields are filled in
                if (string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtEmail.Text) ||
                    string.IsNullOrEmpty(txtContact.Text) ||
                    string.IsNullOrEmpty(txtNic.Text) ||
                    string.IsNullOrEmpty(txtAddress.Text) ||
                    string.IsNullOrEmpty(txtBSalary.Text) ||
                    cbGend.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Open database connection
                Connection.Open();

                // Create SQL command with parameters
                using (SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeTbl (empID, empName, dayPresent, dayAbsence, dayExcuse, period, empNic, empContact) VALUES (@eName, @eGend, @eAddress, @eJDate, @eEmail, @eBSalary, @eNic, @eContact, @eDob)", Connection))
                {
                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@eName", txtName.Text);
                    cmd.Parameters.AddWithValue("@eEmail", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@eContact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@eNic", txtNic.Text);
                    cmd.Parameters.AddWithValue("@eAddress", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@eBSalary", txtBSalary.Text);
                    cmd.Parameters.AddWithValue("@eJDate", DOB.Value.Date);
                    cmd.Parameters.AddWithValue("@eDob", dtJoin.Value.Date);
                    cmd.Parameters.AddWithValue("@eGend", cbGend.SelectedItem.ToString());

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Added!");
                }

                // Refresh the Employee list display
                AttendenceList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Employee: {ex.Message}");
                // Consider logging the error for debugging
            }
            finally
            {
                // Close database connection even in case of errors
                Connection.Close();
            }

            // Clear form fields for the next entry
            Clear_Data();
        }
    }
}
