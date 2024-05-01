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
    public partial class Managers : KryptonForm
    {
        public Managers()
        {
            InitializeComponent();
        }

        // Sql Data Connection
        private SqlConnection Connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False");
        // Sql Data Connection

        //Display Production Registration Details
        private void ManagerList()
        {
            string query = "SELECT mngID, mngName, mngNic, mngPass, mngContact FROM MangerTbl";
            using (SqlConnection connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False"))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    MngDGV.DataSource = dataTable;
                    MngDGV.Refresh();
                }
            }

        }

        //Search Function
        private void TextboxFilter()
        {
            Connection.Open();
            string query = " SELECT * from MangerTbl where mngNic ='" + txtSearch.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            MngDGV.DataSource = dataTable;
            MngDGV.Refresh();
            Connection.Close();

        }

        //Clear Function 
        private void Clear_Data()
        {
            txtName.Text = "";
            txtSYSCode.Text = "";
            txtContact.Text = "";
            txtNic.Text = "";
        }

        // Save Button Click Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate user input to ensure all fields are filled in
                if (string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtSYSCode.Text) ||
                    string.IsNullOrEmpty(txtContact.Text) ||
                    string.IsNullOrEmpty(txtNic.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Open database connection
                Connection.Open();

                // Create SQL command with parameters
                using (SqlCommand cmd = new SqlCommand("INSERT INTO MangerTbl (mngName, mngNic, mngPass, mngContact) VALUES (@mName, @mNic, @mPCode, @mCon)", Connection))
                {
                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@mName", txtName.Text);
                    cmd.Parameters.AddWithValue("@mNic", txtNic.Text);
                    cmd.Parameters.AddWithValue("@mPCode", txtSYSCode.Text);
                    cmd.Parameters.AddWithValue("@mCon", txtContact.Text);

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Manager Added!");
                }

                // Refresh the Employee list display
                ManagerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Manager: {ex.Message}");
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

        // Data Delete Function 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (MngDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Manager to delete.");
                    return;
                }

                // Confirm deletion with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Manager?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Get the model number of the selected Part
                string mNic = MngDGV.SelectedRows[0].Cells["mngNic"].Value.ToString();

                // Open database connection
                Connection.Open();

                // Create SQL command with parameter
                using (SqlCommand cmd = new SqlCommand("DELETE FROM MangerTbl WHERE mngNic = @mNic", Connection))
                {
                    // Add parameter with appropriate data type
                    cmd.Parameters.Add("@mNic", SqlDbType.VarChar).Value = mNic;

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee deleted successfully!");
                }

                // Refresh the Part list display
                ManagerList();

                // Clear Data in Text boxes
                Clear_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting Manager: {ex.Message}");
                // Consider logging the error for debugging
            }
            finally
            {
                // Close database connection even in case of errors
                Connection.Close();
            }
        }

        // data grid View Cell Click Event
        private void MngDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Access the selected row
                DataGridViewRow selectedRow = MngDGV.Rows[e.RowIndex];

                // Retrieve data from the row's cells and assign to textboxes mngName, mngNic, mngPass, mngContact
                txtName.Text = selectedRow.Cells["mngName"].Value.ToString();
                txtNic.Text = selectedRow.Cells["mngNic"].Value.ToString();
                txtContact.Text = selectedRow.Cells["mngContact"].Value.ToString();
                txtSYSCode.Text = selectedRow.Cells["mngPass"].Value.ToString();
            }
        }

        // Data Update click Event 
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (MngDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Manager to update.");
                    return;
                }

                // Validate user input to ensure all fields are filled in (optional, can be commented out if validation is done elsewhere)
                if (string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtSYSCode.Text) ||
                    string.IsNullOrEmpty(txtContact.Text) ||
                    string.IsNullOrEmpty(txtNic.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Get the manager NIC of the selected row
                string mngNic = MngDGV.SelectedRows[0].Cells["mngNic"].Value.ToString();

                // Open database connection
                Connection.Open();

                // Create SQL command with parameters to update the ManagerTbl table
                using (SqlCommand cmd = new SqlCommand("UPDATE MangerTbl SET mngName = @mName, mngPass = @mPCode, mngContact = @mCon WHERE mngNic = @mNic", Connection))
                {
                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@mName", txtName.Text);
                    cmd.Parameters.AddWithValue("@mNic", mngNic); // Use existing NIC for update
                    cmd.Parameters.AddWithValue("@mPCode", txtSYSCode.Text);
                    cmd.Parameters.AddWithValue("@mCon", txtContact.Text);

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Manager details updated successfully!");
                }

                // Refresh the Manager list display
                ManagerList();

                // Clear Data in Text boxes (optional)
                // Clear_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Manager: {ex.Message}");
                // Consider logging the error for debugging
            }
            finally
            {
                // Close database connection even in case of errors
                Connection.Close();
            } 
        }

        private void homePIC_Click(object sender, EventArgs e)
        {
            adminHome adminHome = new adminHome();
            adminHome.Show();
            this.Hide();
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            TextboxFilter();
        }

        private void closePIC_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
