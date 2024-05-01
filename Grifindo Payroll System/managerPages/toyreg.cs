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

namespace Grifindo_Payroll_System.managerPages
{
    public partial class toyreg : KryptonForm
    {
        public toyreg()
        {
            InitializeComponent();
            ToyList();
        }

        // Sql Data Connection
        private SqlConnection Connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False");
        // Sql Data Connection

        //Display Production Registration Details
        private void ToyList()
        {
            string query = "SELECT ToyId, ToyName, ToyMadeDate, ToyMadeCountry, ToyCatagory, Availability, SerialNo, Price, Quantity FROM ToyRegTbl";
            using (SqlConnection connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False"))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    ToysDGV.DataSource = dataTable;
                    ToysDGV.Refresh();
                }
            }

        }

        //Search Function
        private void TextboxFilter()
        {
            Connection.Open();
            string query = " SELECT * from ToyRegTbl where SerialNo ='" + txtSearch.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            ToysDGV.DataSource = dataTable;
            ToysDGV.Refresh();
            Connection.Close();

        }

        //Clear Function 
        private void Clear_Data()
        {
            txtName.Text = "";
            txtCountry.Text = "";
            txtPrice.Text = "";
            txtSerialNo.Text = "";
            cbAvailability.SelectedItem = 0;
            cbCatagory.SelectedItem = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate user input to ensure all fields are filled in
                if (string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtCountry.Text) ||
                    string.IsNullOrEmpty(txtPrice.Text) ||
                    string.IsNullOrEmpty(txtSerialNo.Text) ||
                    cbCatagory.SelectedIndex == -1 ||
                    cbAvailability.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Open database connection
                Connection.Open();

                // Create SQL command with parameters
                using (SqlCommand cmd = new SqlCommand("INSERT INTO ToyRegTbl (ToyName, ToyMadeDate, ToyMadeCountry, ToyCatagory, Availability, SerialNo, Price, Quantity) VALUES (@TName, @TMFD, @TMC, @TCatagory, @TAvailble, @TSN, @TPrice, @TQUT)", Connection))
                {
                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@TName", txtName.Text);
                    cmd.Parameters.AddWithValue("@TMC", txtCountry.Text);
                    cmd.Parameters.AddWithValue("@TSN", txtSerialNo.Text);
                    cmd.Parameters.AddWithValue("@TPrice", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@TQUT", txtQUT.Text);
                    cmd.Parameters.AddWithValue("@TMFD", dtMFD.Value.Date);
                    cmd.Parameters.AddWithValue("@TCatagory", cbCatagory.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TAvailble", cbAvailability.SelectedItem.ToString());

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Added!");
                }

                // Refresh the Employee list display
                ToyList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Toy: {ex.Message}");
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
                if (ToysDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Toy to delete.");
                    return;
                }

                // Confirm deletion with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Toy?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Get the model number of the selected Part
                string TSN = ToysDGV.SelectedRows[0].Cells["SerialNo"].Value.ToString();

                // Open database connection
                Connection.Open();

                // Create SQL command with parameter
                using (SqlCommand cmd = new SqlCommand("DELETE FROM ToyRegTbl WHERE SerialNo = @TSN", Connection))
                {
                    // Add parameter with appropriate data type
                    cmd.Parameters.Add("@TSN", SqlDbType.VarChar).Value = TSN;

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Toy deleted successfully!");
                }

                // Refresh the Part list display
                ToyList();

                // Clear Data in Text boxes
                Clear_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting Toy: {ex.Message}");
                // Consider logging the error for debugging
            }
            finally
            {
                // Close database connection even in case of errors
                Connection.Close();
            }
        }

        private void ToysDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Access the selected row
                DataGridViewRow selectedRow = ToysDGV.Rows[e.RowIndex];

                // Retrieve data from the row's cells and assign to textboxes  
                txtName.Text = selectedRow.Cells["ToyName"].Value.ToString();
                txtCountry.Text = selectedRow.Cells["ToyMadeCountry"].Value.ToString();
                txtSerialNo.Text = selectedRow.Cells["SerialNo"].Value.ToString();
                txtPrice.Text = selectedRow.Cells["Price"].Value.ToString();
                txtQUT.Text = selectedRow.Cells["Quantity"].Value.ToString();
                cbCatagory.Text = selectedRow.Cells["ToyCatagory"].Value.ToString();
                cbAvailability.Text = selectedRow.Cells["Availability"].Value.ToString();
                dtMFD.Text = selectedRow.Cells["ToyMadeDate"].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (ToysDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Toy to update.");
                    return;
                }

                // Validate user input to ensure all fields are filled in
                if (string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtCountry.Text) ||
                    string.IsNullOrEmpty(txtPrice.Text) ||
                    string.IsNullOrEmpty(txtSerialNo.Text) ||
                    cbCatagory.SelectedIndex == -1 ||
                    cbAvailability.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Get model number of the selected Part
                string TSN = ToysDGV.SelectedRows[0].Cells["SerialNo"].Value.ToString();

                // Open database connection
                Connection.Open();

                // Create SQL command with parameters
                using (SqlCommand cmd = new SqlCommand("UPDATE ToyRegTbl SET ToyName = @TName, ToyMadeDate = @TMFD, ToyMadeCountry = @TMC, ToyCatagory = @TCatagory, Availability = @TAvailble, Quantity = @TQUT, Price = @TPrice WHERE SerialNo = @TSN", Connection))
                {
                    // Add parameters with appropriate data types  
                    cmd.Parameters.AddWithValue("@TName", txtName.Text);
                    cmd.Parameters.AddWithValue("@TMC", txtCountry.Text);
                    cmd.Parameters.AddWithValue("@TSN", TSN);
                    cmd.Parameters.AddWithValue("@TPrice", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@TQUT", txtQUT.Text);
                    cmd.Parameters.AddWithValue("@TMFD", dtMFD.Value.Date);
                    cmd.Parameters.AddWithValue("@TCatagory", cbCatagory.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TAvailble", cbAvailability.SelectedItem.ToString());

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Toy updated successfully!");
                }

                // Refresh the Toy list display
                ToyList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Toy: {ex.Message}");
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

        private void closePIC_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void homePIC_Click(object sender, EventArgs e)
        {
            managerHome managerHome = new managerHome();
            managerHome.Show();
            this.Hide();
        }

        private void empPIC_Click(object sender, EventArgs e)
        {
            employee employee = new employee();
            employee.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            attendence attendence = new attendence();
            attendence.Show();
            this.Hide();
        }

        private void bonousPIC_Click(object sender, EventArgs e)
        {
            toyreg toyreg = new toyreg();
            toyreg.Show();
            this.Hide();
        }

        private void salaryPIC_Click(object sender, EventArgs e)
        {
            salary salary = new salary();
            salary.Show();
            this.Hide();
        }

        private void advancedPIC_Click(object sender, EventArgs e)
        {
            advanced advanced = new advanced();
            advanced.Show();
            this.Hide();
        }
    }
}
