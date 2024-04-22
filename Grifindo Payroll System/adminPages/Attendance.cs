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
                    AttendenceDGV.DataSource = dataTable;
                    AttendenceDGV.Refresh();
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
            AttendenceDGV.DataSource = dataTable;
            AttendenceDGV.Refresh();
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
            foreach(DataRow dataRow in dataTable.Rows)
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

        // Save Button Click Event 
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate user input to ensure all fields are filled in
                if (string.IsNullOrEmpty(txtPresent.Text) ||
                    string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty (txtContact.Text) ||
                    string.IsNullOrEmpty (txtNic.Text) ||
                    string.IsNullOrEmpty(txtExcuses.Text) ||
                    string.IsNullOrEmpty(txtAbsence.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Open database connection
                Connection.Open();
                string period = dtperiod.Value.Month + " - " + dtperiod.Value.Year;

                // Create SQL command with parameters
                using (SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeTbl (empID, empName, dayPresent, dayAbsence, dayExcuse, period, empNic, empContact) VALUES (@eID, @eName, @eDPresent, @eDAbsence, @eDExcuse, @APeriod, @eNic, @eContact)", Connection))
                {
                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@eID", cbEmpID.Text);
                    cmd.Parameters.AddWithValue("@eName", txtName.Text);
                    cmd.Parameters.AddWithValue("@eDPresent", txtPresent.Text);
                    cmd.Parameters.AddWithValue("@eDAbsence", txtAbsence.Text);
                    cmd.Parameters.AddWithValue("@eDExcuse", txtExcuses.Text);
                    cmd.Parameters.AddWithValue("@eNic", txtNic.Text);
                    cmd.Parameters.AddWithValue("@APeriod", period);
                    cmd.Parameters.AddWithValue("@eContact",txtContact.Text );
                    

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Added!");
                }

                // Refresh the Attendeance list display
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

        // Attendence Update button Function 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate user input to ensure essential fields are filled
                if (string.IsNullOrEmpty(txtPresent.Text) ||
                    string.IsNullOrEmpty(txtAbsence.Text) ||
                    string.IsNullOrEmpty(txtExcuses.Text))
                {
                    MessageBox.Show("Please fill in Present Days, Absent Days and Excuses fields.");
                    return;
                }

                // Open database connection
                Connection.Open();

                // Prepare the SQL update statement with parameters
                string updateQuery = "UPDATE AttendenceTbl SET dayPresent = @eDPresent, dayAbsence = @eDAbsence, dayExcuse = @eDExcuse WHERE empID = @eID";
                using (SqlCommand cmd = new SqlCommand(updateQuery, Connection))
                {
                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@eID", cbEmpID.SelectedValue);
                    cmd.Parameters.AddWithValue("@eDPresent", txtPresent.Text);
                    cmd.Parameters.AddWithValue("@eDAbsence", txtAbsence.Text);
                    cmd.Parameters.AddWithValue("@eDExcuse", txtExcuses.Text);

                    // Execute the update command
                    int rowsUpdated = cmd.ExecuteNonQuery();

                    // Check if any rows were updated
                    if (rowsUpdated > 0)
                    {
                        MessageBox.Show("Attendance Updated Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No records found to update.");
                    }
                }

                // Refresh the Attendance list display
                AttendenceList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Attendance: {ex.Message}");
                // Consider logging the error for debugging
            }
            finally
            {
                // Close database connection even in case of errors
                Connection.Close();
            }

            // Optionally, clear form fields after successful update
             Clear_Data();
        }

        // Data Delete button click event Function 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this attendance record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    // Validate selection
                    if (cbEmpID.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select an employee record to delete.");
                        return;
                    }

                    // Open database connection
                    Connection.Open();

                    // Prepare the SQL delete statement with a parameter
                    string deleteQuery = "DELETE FROM AttendenceTbl WHERE empID = @eID";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, Connection))
                    {
                        // Add parameter with appropriate data type
                        cmd.Parameters.AddWithValue("@eID", cbEmpID.SelectedValue);

                        // Execute the delete command
                        int rowsDeleted = cmd.ExecuteNonQuery();

                        // Check if any rows were deleted
                        if (rowsDeleted > 0)
                        {
                            MessageBox.Show("Attendance record deleted successfully!");
                            // Clear form fields after successful deletion (optional)
                            Clear_Data();
                        }
                        else
                        {
                            MessageBox.Show("No records found to delete.");
                        }
                    }

                    // Refresh the Attendance list display
                    AttendenceList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting Attendance record: {ex.Message}");
                    // Consider logging the error for debugging
                }
                finally
                {
                    // Close database connection even in case of errors
                    Connection.Close();
                }
            }
        }

        // Search button click event
        private void picSearch_Click(object sender, EventArgs e)
        {
            TextboxFilter();
        }
    }
}
