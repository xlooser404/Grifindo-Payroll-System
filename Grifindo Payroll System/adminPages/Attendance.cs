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
using Grifindo_Payroll_System.adminPages;

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
            txtContact.Text = "";
            txtAbsence.Text = "";
            txtPresent.Text = "";
            txtExcuses.Text = "";
            txtNic.Text = "";
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
            if (cbEmpID.SelectedIndex > -1) // Check if an item is selected
            {
                Connection.Open();
                int selectedEmpID = int.Parse(cbEmpID.SelectedValue.ToString()); // Convert to integer
                SqlCommand cmd = new SqlCommand("Select * from EmployeeTbl where empID = @empID", Connection);
                cmd.Parameters.AddWithValue("@empID", selectedEmpID); // Use parameter for safe value assignment
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0) // Check if data exists for selected ID
                {
                    DataRow dataRow = dataTable.Rows[0];
                    txtName.Text = dataRow["empName"].ToString();
                    txtNic.Text = dataRow["empNic"].ToString();
                    txtContact.Text = dataRow["empContact"].ToString();
                }
                else
                {
                    // Handle case where no employee found (optional: display message)
                }
            }
            Connection.Close();
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
                    string.IsNullOrEmpty(txtContact.Text) ||
                    string.IsNullOrEmpty(txtNic.Text) ||
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
                using (SqlCommand cmd = new SqlCommand("INSERT INTO AttendenceTbl (empID, empName, dayPresent, dayAbsence, dayExcuse, period, empNic, empContact) VALUES (@eID, @eName, @eDPresent, @eDAbsence, @eDExcuse, @APeriod, @eNic, @eContact)", Connection))
                {
                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@eID", cbEmpID.Text);
                    cmd.Parameters.AddWithValue("@eName", txtName.Text);
                    cmd.Parameters.AddWithValue("@eDPresent", txtPresent.Text);
                    cmd.Parameters.AddWithValue("@eDAbsence", txtAbsence.Text);
                    cmd.Parameters.AddWithValue("@eDExcuse", txtExcuses.Text);
                    cmd.Parameters.AddWithValue("@eNic", txtNic.Text);
                    cmd.Parameters.AddWithValue("@APeriod", period);
                    cmd.Parameters.AddWithValue("@eContact", txtContact.Text);


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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (AttendenceDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Employee to delete.");
                    return;
                }

                // Confirm deletion with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Attedence?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Get the model number of the selected Part
                string eNic = AttendenceDGV.SelectedRows[0].Cells["empNic"].Value.ToString();

                // Open database connection
                Connection.Open();

                // Create SQL command with parameter
                using (SqlCommand cmd = new SqlCommand("DELETE FROM  WHERE empNic = @eNic", Connection))
                {
                    // Add parameter with appropriate data type
                    cmd.Parameters.Add("@empNic", SqlDbType.VarChar).Value = eNic;

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attedence deleted successfully!");
                }

                // Refresh the Part list display
                AttendenceList();

                // Clear Data in Text boxes
                Clear_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting Attedence: {ex.Message}");
                // Consider logging the error for debugging
            }
            finally
            {
                // Close database connection even in case of errors
                Connection.Close();
            }
        }

        // Data Grid View Cell Click Function 
        private void AttendenceDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Access the selected row
                DataGridViewRow selectedRow = AttendenceDGV.Rows[e.RowIndex];

                // Retrieve data from the row's cells and assign to textboxes 
                cbEmpID.Text = selectedRow.Cells["empID"].Value.ToString();
                txtName.Text = selectedRow.Cells["empName"].Value.ToString();
                dtperiod.Text = selectedRow.Cells["period"].Value.ToString(); // Cast to DateTime
                txtPresent.Text = selectedRow.Cells["dayPresent"].Value.ToString();
                txtAbsence.Text = selectedRow.Cells["dayAbsence"].Value.ToString();
                txtExcuses.Text = selectedRow.Cells["dayExcuse"].Value.ToString();
                txtNic.Text = selectedRow.Cells["empNic"].Value.ToString();
                txtContact.Text = selectedRow.Cells["empContact"].Value.ToString();
            }
        }

        //  Update button click Event 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate user input to ensure all fields are filled in
                if (string.IsNullOrEmpty(txtPresent.Text) ||
                    string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtContact.Text) ||
                    string.IsNullOrEmpty(txtNic.Text) ||
                    string.IsNullOrEmpty(txtExcuses.Text) ||
                    string.IsNullOrEmpty(txtAbsence.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Ensure a row is selected
                if (AttendenceDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an attendance record to update.");
                    return;
                }

                // Get the selected employee's NIC for identification
                string selectedNic = AttendenceDGV.SelectedRows[0].Cells["empNic"].Value.ToString();

                // Open database connection
                Connection.Open();

                string period = dtperiod.Value.Month + " - " + dtperiod.Value.Year;

                // Create SQL command with parameters for update
                using (SqlCommand cmd = new SqlCommand(
                  "UPDATE AttendenceTbl SET empID = @eID, empName = @eName, dayPresent = @eDPresent, dayAbsence = @eDAbsence, dayExcuse = @eDExcuse, period = @APeriod, empContact = @eContact WHERE empNic = @eNic", Connection))
                {
                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@eID", cbEmpID.Text);
                    cmd.Parameters.AddWithValue("@eName", txtName.Text);
                    cmd.Parameters.AddWithValue("@eDPresent", txtPresent.Text);
                    cmd.Parameters.AddWithValue("@eDAbsence", txtAbsence.Text);
                    cmd.Parameters.AddWithValue("@eDExcuse", txtExcuses.Text);
                    cmd.Parameters.AddWithValue("@eNic", selectedNic); // Use selected NIC for update
                    cmd.Parameters.AddWithValue("@APeriod", period);
                    cmd.Parameters.AddWithValue("@eContact", txtContact.Text);

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendance record updated successfully!");
                }

                // Refresh the attendance list display
                AttendenceList();

                // Clear form fields (optional)
                Clear_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating attendance: {ex.Message}");
                // Consider logging the error for debugging
            }
            finally
            {
                // Close database connection even in case of errors
                Connection.Close();
            }
        }

        // Search ico click event
        private void picSearch_Click(object sender, EventArgs e)
        {
            TextboxFilter();
        }

        private void logoutPIC_Click(object sender, EventArgs e)
        {
            loginselection loginselection = new loginselection();
            loginselection.Show();
            this.Hide();
        }

        private void txtlogout_Click(object sender, EventArgs e)
        {
            loginselection loginselection = new loginselection();
            loginselection.Show();
            this.Hide();
        }

        private void homePIC_Click(object sender, EventArgs e)
        {
            adminHome adminHome = new adminHome();
            adminHome.Show();
            this.Hide();
        }

        private void empPIC_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
            this.Hide();
        }

        private void bonousPIC_Click(object sender, EventArgs e)
        {
            ToyReg toyReg = new ToyReg();
            toyReg.Show();
            this.Hide();
        }

        private void salaryPIC_Click(object sender, EventArgs e)
        {
            Salary salary = new Salary();
            salary.Show();
            this.Hide();
        }

        private void advancedPIC_Click(object sender, EventArgs e)
        {
            Advanced advanced = new Advanced(); 
            advanced.Show();
            this.Hide();
        }

        private void closePIC_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
