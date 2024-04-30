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
    public partial class Bonous : KryptonForm
    {
        public Bonous()
        {
            InitializeComponent();
            BonousList();
        }

        // Sql Data Connection
        private SqlConnection Connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False");
        // Sql Data Connection

        // Display Attendence Details
        private void BonousList()
        {
            string query = "SELECT bonousID, bonousName, bonousCode, bonousDetail, bounousAmount FROM BonousTbl";
            using (SqlConnection connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False"))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    BonousDGV.DataSource = dataTable;
                    BonousDGV.Refresh();
                }
            }

        }

        // Search Function
        private void TextboxFilter()
        {
            Connection.Open();
            string query = " SELECT * from BonousTbl where bonousCode ='" + txtSearch.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            BonousDGV.DataSource = dataTable;
            BonousDGV.Refresh();
            Connection.Close();

        }

        private void Clear_Data()
        {
            txtName.Text = "";
            txtDetails.Text = "";
            txtCode.Text = "";
            txtAmount.Text = "";
        }

        // Data Add Button Click Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate user input to ensure all fields are filled in
                if (string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtDetails.Text) ||
                    string.IsNullOrEmpty(txtCode.Text) ||
                    string.IsNullOrEmpty(txtAmount.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Open database connection
                Connection.Open();

                // Create SQL command with parameters
                using (SqlCommand cmd = new SqlCommand("INSERT INTO BonousTbl (bonousName, bonousCode, bonousDetail, bounousAmount) VALUES (@bName, @bCode, @bDetail, @bAmount)", Connection))
                {
                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@bName", txtName.Text);
                    cmd.Parameters.AddWithValue("@bDetail", txtDetails.Text);
                    cmd.Parameters.AddWithValue("@bCode", txtCode.Text);
                    cmd.Parameters.AddWithValue("@bAmount", txtAmount.Text);

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bonous Added!");
                }

                // Refresh the Employee list display
                BonousList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Bonous: {ex.Message}");
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

        // Data Delete Button Click Event 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (BonousDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Bonous to delete.");
                    return;
                }

                // Confirm deletion with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Bonous?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Get the model number of the selected Part
                string bCode = BonousDGV.SelectedRows[0].Cells["bonousCode"].Value.ToString();

                // Open database connection
                Connection.Open();

                // Create SQL command with parameter
                using (SqlCommand cmd = new SqlCommand("DELETE FROM BonousTbl WHERE bonousCode = @bCode", Connection))
                {
                    // Add parameter with appropriate data type
                    cmd.Parameters.Add("@bCode", SqlDbType.VarChar).Value = bCode;

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bonous deleted successfully!");
                }

                // Refresh the Part list display
                BonousList();

                // Clear Data in Text boxes
                Clear_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting Bonous: {ex.Message}");
                // Consider logging the error for debugging
            }
            finally
            {
                // Close database connection even in case of errors
                Connection.Close();
            }
        }

        // Data Grid View Cell Click event
        private void BonousDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Access the selected row
                DataGridViewRow selectedRow = BonousDGV.Rows[e.RowIndex];

                // Retrieve data from the row's cells and assign to textboxes  
                txtName.Text = selectedRow.Cells["bonousName"].Value.ToString();
                txtDetails.Text = selectedRow.Cells["bonousDetail"].Value.ToString();
                txtCode.Text = selectedRow.Cells["bonousCode"].Value.ToString();
                txtAmount.Text = selectedRow.Cells["bounousAmount"].Value.ToString();
            }
        }

        // Data Update Function; Edit Button Click Event 
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (BonousDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Employee to update.");
                    return;
                }

                // Validate user input to ensure all fields are filled in
                if (string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtDetails.Text) ||
                    string.IsNullOrEmpty(txtCode.Text) ||
                    string.IsNullOrEmpty(txtAmount.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Get model number of the selected Part
                string bCode = BonousDGV.SelectedRows[0].Cells["bonousCode"].Value.ToString();

                // Open database connection
                Connection.Open();

                // Create SQL command with parameters   bonousName, bonousCode, bonousDetail, bounousAmount
                using (SqlCommand cmd = new SqlCommand("UPDATE BonousTbl SET bonousName = @bName, bonousDetail = @bDetail, bounousAmount = @bAmount WHERE bonousCode = @bCode", Connection))
                {
                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@bName", txtName.Text);
                    cmd.Parameters.AddWithValue("@bDetail", txtDetails.Text);
                    cmd.Parameters.AddWithValue("@bCode", bCode);
                    cmd.Parameters.AddWithValue("@bAmount", txtAmount.Text);

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee updated successfully!");
                }

                // Refresh the Employee list display
                BonousList();
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
    }
}
