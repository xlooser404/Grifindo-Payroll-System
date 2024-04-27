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

namespace Grifindo_Payroll_System.adminPages
{
    public partial class Advanced : KryptonForm
    {
        public Advanced()
        {
            InitializeComponent();
            getEmployeeID();
            OvertimeList();

        }

        // Sql Data Connection
        private SqlConnection Connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False");
        // Sql Data Connection

        // Display OverTime Details
        private void OvertimeList()
        {
            string query = "SELECT adID, empID, empName, empNic, OverTime, OTrate FROM AdvancedTbl";
            using (SqlConnection connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False"))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    AdvanceDGV.DataSource = dataTable;
                    AdvanceDGV.Refresh();
                }
            }

        }

        // Search Function
        private void TextboxFilter()
        {
            Connection.Open();
            string query = " SELECT * from AdvancedTbl where empNic ='" + txtSearch.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            AdvanceDGV.DataSource = dataTable;
            AdvanceDGV.Refresh();
            Connection.Close();

        }

        private void Clear_Data()
        {
            txtName.Text = "";
            txtNic.Text = "";
            txtOT.Text = "";
            OTratrTb.Text = "";
        }

        // Get Employee ID to Ot form
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
                }
                else
                {
                    MessageBox.Show("No Employee Founded");
                }
            }
            Connection.Close();
        }

        private void cbEmpID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getEmployeedetails();
        }

        // Save button Click Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate user input to ensure all fields are filled in
                if (string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtNic.Text) ||
                    string.IsNullOrEmpty(txtOT.Text) ||
                    string.IsNullOrEmpty(OTratrTb.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Open database connection
                Connection.Open();

                // Create SQL command with parameters
                using (SqlCommand cmd = new SqlCommand("INSERT INTO AdvancedTbl (empID, empName, empNic, OverTime, OTrate) VALUES (@eID, @eName, @eNic, @eOT, @eOTr)", Connection))
                {
                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@eID", cbEmpID.Text);
                    cmd.Parameters.AddWithValue("@eName", txtName.Text);
                    cmd.Parameters.AddWithValue("@eNic", txtNic.Text);
                    cmd.Parameters.AddWithValue("@eOT", txtOT.Text);
                    cmd.Parameters.AddWithValue("@eOTr", OTratrTb.Text);


                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Over Time Detail Added!");
                }

                // Refresh the Attendeance list display
                OvertimeList();
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

        // Delete Function Click Event
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (AdvanceDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a OT-Dtail to delete.");
                    return;
                }

                // Confirm deletion with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this OT-Detail?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Get the model number of the selected Part
                string eNic = AdvanceDGV.SelectedRows[0].Cells["empNic"].Value.ToString();

                // Open database connection
                Connection.Open();

                // Create SQL command with parameter
                using (SqlCommand cmd = new SqlCommand("DELETE FROM  WHERE empNic = @eNic", Connection))
                {
                    // Add parameter with appropriate data type
                    cmd.Parameters.Add("@empNic", SqlDbType.VarChar).Value = eNic;

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("OT-detail deleted successfully!");
                }

                // Refresh the Part list display
                OvertimeList();

                // Clear Data in Text boxes
                Clear_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting OT-Deatls: {ex.Message}");
                // Consider logging the error for debugging
            }
            finally
            {
                // Close database connection even in case of errors
                Connection.Close();
            }
        }

        // Data Grid View Cell click event
        private void AdvanceDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Access the selected row
                DataGridViewRow selectedRow = AdvanceDGV.Rows[e.RowIndex];

                // Retrieve data from the row's cells and assign to textboxes 
                cbEmpID.Text = selectedRow.Cells["empID"].Value.ToString();
                txtName.Text = selectedRow.Cells["empName"].Value.ToString();
                txtNic.Text = selectedRow.Cells["empNic"].Value.ToString();
                txtOT.Text = selectedRow.Cells["OverTime"].Value.ToString();
                OTratrTb.Text = selectedRow.Cells["OTrate"].Value.ToString();
            }
        }

        // Edit Button Click Event 
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate user input to ensure all fields are filled in
                if (string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtNic.Text) ||
                    string.IsNullOrEmpty(txtOT.Text) ||
                    string.IsNullOrEmpty(OTratrTb.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Ensure a row is selected
                if (AdvanceDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an Over Time record to update.");
                    return;
                }

                // Get the selected employee's NIC for identification
                string selectedNic = AdvanceDGV.SelectedRows[0].Cells["empNic"].Value.ToString();

                // Open database connection
                Connection.Open();

                // Create SQL command with parameters for update 
                using (SqlCommand cmd = new SqlCommand(
                  "UPDATE AttendenceTbl SET empID = @eID, empName = @eName, OverTime = @eOT, OTrate = @eOTr WHERE empNic = @eNic", Connection))
                {
                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@eID", cbEmpID.Text);
                    cmd.Parameters.AddWithValue("@eName", txtName.Text);
                    cmd.Parameters.AddWithValue("@eOT", txtOT.Text);
                    cmd.Parameters.AddWithValue("@eDAbsence", OTratrTb.Text);
                    cmd.Parameters.AddWithValue("@eNic", selectedNic); // Use selected NIC for update

                    // Execute the update command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("overtime record updated successfully!");
                }

                // Refresh the attendance list display
                OvertimeList();

                // Clear form fields (optional)
                Clear_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Ot-Detail: {ex.Message}");
                // Consider logging the error for debugging
            }
            finally
            {
                // Close database connection even in case of errors
                Connection.Close();
            }
        }
    }
}
