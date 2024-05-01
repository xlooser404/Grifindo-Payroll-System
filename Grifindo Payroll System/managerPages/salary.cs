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
    public partial class salary : KryptonForm
    {
        public salary()
        {
            InitializeComponent();
            SalaryList();
            getEmployeeID();
            getAttendence();
            getBonous();
        }

        // Sql Data Connection
        private SqlConnection Connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False");
        // Sql Data Connection

        // Display Attendence Details
        private void SalaryList()
        {
            string query = "SELECT salID, empID, empName, empBSal, empBonous, empOT, empOTRate, empNic, empBalance, salPeriod FROM SalaryTbl";
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
            string query = " SELECT * from SalaryTbl where empNic ='" + txtSearch.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            SalaryDGV.DataSource = dataTable;
            SalaryDGV.Refresh();
            Connection.Close();

        }

        // Get Employee ID to Salary issue form
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

        // Get Attendence to to Salary issue form
        private void getAttendence()
        {
            if (cbEmpID.SelectedIndex > -1)
            {
                Connection.Open();
                int selectedEmpID = int.Parse(cbEmpID.SelectedValue.ToString());
                SqlCommand cmd = new SqlCommand("Select AttendID from AttendenceTbl Where empID = @empID", Connection);
                cmd.Parameters.AddWithValue("@empID", selectedEmpID);

                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);

                cbAttend.ValueMember = "AttendID"; // Set AttendID as the value member
                cbAttend.DataSource = dataTable;

                Connection.Close();
            }
        }

        // Get Bonous to Salary issue form
        private void getBonous()
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand("Select bonousName from BonousTbl", Connection); // Retrieve only bonous names

            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);

            cbBonousName.ValueMember = "bonousName"; // Set bonousName as the value member
            cbBonousName.DataSource = dataTable;

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
                    txtBSalary.Text = dataRow["empBSalary"].ToString();
                }
                else
                {
                    // Handle case where no employee found (optional: display message)
                }
            }
            Connection.Close();
        }

        // Get Over Time Rate Details Using when Select Employe ID
        private void getOverTimeDetail()
        {
            if (cbEmpID.SelectedIndex > -1)
            {
                Connection.Open();
                int selectedEmpID = int.Parse(cbEmpID.SelectedValue.ToString()); // Convert to integer
                SqlCommand cmd = new SqlCommand("Select * from AdvancedTbl Where empID = @empID", Connection);
                cmd.Parameters.AddWithValue("@empID", selectedEmpID); // Use parameter for safe value assignment
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    // Assuming the overtime field is named "OverTime" in AdvanceTbl
                    double overtime = double.Parse(dataRow["OverTime"].ToString());
                    txtOT.Text = overtime.ToString(); // Set overtime value in textbox
                    double OTRate = double.Parse(dataRow["OTrate"].ToString());
                    OTratrTb.Text = OTRate.ToString();

                }
                else
                {
                    txtOT.Text = "0"; // Set overtime to 0 if no data found
                    OTratrTb.Text = "0"; // Set OTrate to 0 if no data found
                }
                Connection.Close();
            }
        }

        // Get Bonous Amount
        private void getBonousAmt()
        {
            if (cbEmpID.SelectedIndex > -1) // Check if an employee is selected
            {
                Connection.Open();
                string selectedBName = cbBonousName.SelectedValue.ToString(); // Get the selected bonus name as string
                SqlCommand cmd = new SqlCommand("Select * from BonousTbl where bonousName = @BName", Connection);
                cmd.Parameters.AddWithValue("@BName", selectedBName);  // Use parameter for safe value assignment

                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0) // Check if data exists for selected name
                {
                    DataRow dataRow = dataTable.Rows[0];
                    txtBonous.Text = dataRow["bounousAmount"].ToString();
                }
                else
                {
                    txtBonous.Text = "0"; // Set bonus amount to 0 if not found
                }
                Connection.Close();
            }
        }

        // Get Bonous Amount
        private void getAttedenceData()
        {
            if (cbEmpID.SelectedIndex > -1) // Check if an item is selected
            {
                Connection.Open();
                int selectedatID = int.Parse(cbAttend.SelectedValue.ToString()); // Convert to integer
                SqlCommand cmd = new SqlCommand("Select * from AttendenceTbl where AttendID = @atID", Connection);
                cmd.Parameters.AddWithValue("@atID", selectedatID); // Use parameter for safe value assignment
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0) // Check if data exists for selected ID
                {
                    DataRow dataRow = dataTable.Rows[0];
                    txtAbsence.Text = dataRow["dayAbsence"].ToString();
                    txtExcuses.Text = dataRow["dayExcuse"].ToString();
                    txtpresence.Text = dataRow["dayPresent"].ToString();
                }
                else
                {
                    // Handle case where no employee found (optional: display message)
                }
            }
            Connection.Close();
        }

        // Clear_Data Function 
        private void Clear_Data()
        {

            txtAbsence.Text = "";
            txtBonous.Text = "";
            txtBSalary.Text = "";
            txtExcuses.Text = "";
            txtlogout.Text = "";
            txtName.Text = "";
            txtNic.Text = "";
            txtOT.Text = "";
            txtpresence.Text = "";
        }

        private void cbEmpID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getEmployeedetails();
            getOverTimeDetail();
            getAttendence();
        }

        private void cbBonousName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getBonousAmt();
        }

        private void cbAttend_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getAttedenceData();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Get all the required values from UI elements (textboxes)

                double basicSalary = double.Parse(txtBSalary.Text);
                double overtimeHours = double.Parse(txtOT.Text);
                double overtimeRate = double.Parse(OTratrTb.Text);
                double bonusAmount = double.Parse(txtBonous.Text);

                // Calculate Gross Salary
                double grossSalary = basicSalary + (overtimeHours * overtimeRate);
                // Calculate Net Salary
                double deductions = 0;
                // Display the calculated Net Salary in a textbox
                double netSalary = grossSalary - deductions + bonusAmount;

                TSalaryTb.Text = netSalary.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate user input to ensure all fields are filled in
                if (string.IsNullOrEmpty(txtName.Text) ||
                    string.IsNullOrEmpty(txtBSalary.Text) ||
                    string.IsNullOrEmpty(txtBonous.Text) ||
                    string.IsNullOrEmpty(txtOT.Text) ||
                    string.IsNullOrEmpty(TSalaryTb.Text) ||
                    string.IsNullOrEmpty(OTratrTb.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                // Open database connection
                Connection.Open();
                string period = dtperiod.Value.Month + " - " + dtperiod.Value.Year;

                // Create SQL command with parameters
                using (SqlCommand cmd = new SqlCommand("INSERT INTO SalaryTbl (empID, empName, empBSal, empBonous, empOT, empOTRate, empNic, empBalance, salPeriod) VALUES (@eID, @eName, @eBSal, @eBonous, @eOT, @eOTR, @eNic, @eBalance, @eSPeriod)", Connection))
                {
                    // Add parameters with appropriate data types
                    cmd.Parameters.AddWithValue("@eID", cbEmpID.Text);
                    cmd.Parameters.AddWithValue("@eName", txtName.Text);
                    cmd.Parameters.AddWithValue("@eBSal", txtBSalary.Text);
                    cmd.Parameters.AddWithValue("@eBonous", txtBonous.Text);
                    cmd.Parameters.AddWithValue("@eOT", txtOT.Text);
                    cmd.Parameters.AddWithValue("@eOTR", OTratrTb.Text);
                    cmd.Parameters.AddWithValue("@eSPeriod", period);
                    cmd.Parameters.AddWithValue("@eNic", txtNic.Text);
                    cmd.Parameters.AddWithValue("@eBalance", TSalaryTb.Text);


                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Salary Added!");
                }

                // Refresh the Attendeance list display
                SalaryList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding Salary: {ex.Message}");
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

        private void SalaryDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Access the selected row
                DataGridViewRow selectedRow = SalaryDGV.Rows[e.RowIndex];

                // Retrieve data from the row's cells and assign to textboxes 
                cbEmpID.Text = selectedRow.Cells["empID"].Value.ToString();
                txtName.Text = selectedRow.Cells["empName"].Value.ToString();
                dtperiod.Text = selectedRow.Cells["salPeriod"].Value.ToString(); // Cast to DateTime  
                txtBSalary.Text = selectedRow.Cells["empBSal"].Value.ToString();
                txtBonous.Text = selectedRow.Cells["empBonous"].Value.ToString();
                txtOT.Text = selectedRow.Cells["empOT"].Value.ToString();
                txtNic.Text = selectedRow.Cells["empNic"].Value.ToString();
                OTratrTb.Text = selectedRow.Cells["empOTRate"].Value.ToString();
                TSalaryTb.Text = selectedRow.Cells["empBalance"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (SalaryDGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Salary to delete.");
                    return;
                }

                // Confirm deletion with the user
                DialogResult result = MessageBox.Show("Are you sure you want to delete this Salary?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Get the employee NIC of the selected row
                string eNic = SalaryDGV.SelectedRows[0].Cells["empNic"].Value.ToString();

                // Open database connection
                Connection.Open();

                // Create SQL command with parameter, specify the table name to delete from
                using (SqlCommand cmd = new SqlCommand("DELETE FROM SalaryTbl WHERE empNic = @eNic", Connection))
                {
                    // Add parameter with appropriate data type
                    cmd.Parameters.Add("@eNic", SqlDbType.VarChar).Value = eNic;

                    // Execute the command
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Salary deleted successfully!");
                }

                // Refresh the Salary list display
                SalaryList();

                // Clear Data in Text boxes
                Clear_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting Salary: {ex.Message}");
                // Consider logging the error for debugging
            }
            finally
            {
                // Close database connection even in case of errors
                Connection.Close();
            }
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

        private void advancedPIC_Click(object sender, EventArgs e)
        {
            advanced advanced = new advanced();
            advanced.Show();
            this.Hide();
        }
    }
}
