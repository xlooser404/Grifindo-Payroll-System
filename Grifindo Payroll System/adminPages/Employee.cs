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
    public partial class Employee : KryptonForm
    {
        public Employee()
        {
            InitializeComponent();
            EmployeeList();
        }
        // Sql Data Connection
        private SqlConnection Connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False");
        // Sql Data Connection

        //Display Production Registration Details
        private void EmployeeList()
        {
            string query = "SELECT empID, empName, empGend, empAddress, empJDate, empEmail, empBSalary, empNic, empContact, empDOB FROM EmployeeTbl";
            using (SqlConnection connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False"))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    EmployeeDGV.DataSource = dataTable;
                    EmployeeDGV.Refresh();
                }
            }

        }

        //Search Function
        private void TextboxFilter()
        {
            Connection.Open();
            string query = " SELECT * from EmployeeTbl where empNic ='" + txtSearch.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            EmployeeDGV.DataSource = dataTable;
            EmployeeDGV.Refresh();
            Connection.Close();

        }

        //Clear Function 
        private void Clear_Data()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtNic.Text = "";
            txtAddress.Text = "";
            cbGend.SelectedItem = 0;
            txtBSalary.Text = "";
            txtAddress.Text = "";
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
                using (SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeTbl (empName, empGend, empAddress, empJDate, empEmail, empBSalary, empNic, empContact, empDOB) VALUES (@eName, @eGend, @eAddress, @eJDate, @eEmail, @eBSalary, @eNic, @eContact, @eDob)", Connection))
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
                EmployeeList();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (EmployeeDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Employee to delete.");
                    return;
                }

                // Confirm deletion with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Employee?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Get the model number of the selected Part
                string eNic = EmployeeDGV.SelectedRows[0].Cells["empNic"].Value.ToString();

                // Open database connection
                Connection.Open();

                // Create SQL command with parameter
                using (SqlCommand cmd = new SqlCommand("DELETE FROM EmployeeTbl WHERE empNic = @eNic", Connection))
                {
                    // Add parameter with appropriate data type
                    cmd.Parameters.Add("@empNic", SqlDbType.VarChar).Value = eNic;

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee deleted successfully!");
                }

                // Refresh the Part list display
                EmployeeList();

                // Clear Data in Text boxes
                Clear_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting Employee: {ex.Message}");
                // Consider logging the error for debugging
            }
            finally
            {
                // Close database connection even in case of errors
                Connection.Close();
            }
        }

        // Data Grid View Cell Click Function 
        private void EmployeeDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Access the selected row
                DataGridViewRow selectedRow = EmployeeDGV.Rows[e.RowIndex];

                // Retrieve data from the row's cells and assign to textboxes 
                txtName.Text = selectedRow.Cells["empName"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["empEmail"].Value.ToString();
                txtContact.Text = selectedRow.Cells["empContact"].Value.ToString();
                txtNic.Text = selectedRow.Cells["empNic"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["empAddress"].Value.ToString();
                cbGend.Text = selectedRow.Cells["empGend"].Value.ToString();
                txtBSalary.Text = selectedRow.Cells["empBSalary"].Value.ToString();
                DOB.Text = selectedRow.Cells["empDOB"].Value.ToString();
                dtJoin.Text = selectedRow.Cells["empJDate"].Value.ToString();
            }
        }

        //  Update button click Event 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (EmployeeDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Employee to update.");
                    return;
                }

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

                // Get model number of the selected Part
                string eNic = EmployeeDGV.SelectedRows[0].Cells["empNic"].Value.ToString();

                // Open database connection
                Connection.Open();

                // Create SQL command with parameters
                using (SqlCommand cmd = new SqlCommand("UPDATE EmployeeTbl SET empName = @eName, empGend = @eGend, empAddress = @eAddress, empJDate = @eJDate, empEmail = @eEmail, empBSalary = @eBSalary, empContact = @eContact, empDOB = @eDob WHERE empNic = @eNic", Connection))
                {
                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@eName", txtName.Text);
                    cmd.Parameters.AddWithValue("@eEmail", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@eContact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@eNic", eNic);
                    cmd.Parameters.AddWithValue("@eAddress", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@eBSalary", txtBSalary.Text);
                    cmd.Parameters.AddWithValue("@eJDate", DOB.Value.Date);
                    cmd.Parameters.AddWithValue("@eDob", dtJoin.Value.Date);
                    cmd.Parameters.AddWithValue("@eGend", cbGend.SelectedItem.ToString());

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee updated successfully!");
                }

                // Refresh the Employee list display
                EmployeeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Employee: {ex.Message}");
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

        private void picSearch_Click(object sender, EventArgs e)
        {
            TextboxFilter();
        }

        private void homePIC_Click(object sender, EventArgs e)
        {
            adminHome adminHome = new adminHome();
            adminHome.Show();
            this.Hide();
        }
    }
}
