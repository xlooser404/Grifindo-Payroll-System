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
            string query = "SELECT salID, empID, empName, empBSal, empBonous, empAdvanced, empOT, empBalance, salPeriod FROM SalaryTbl";
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
            if (cbBonous.SelectedIndex > -1) // Check if an item is selected
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand("Select * from BonousTbl where bonousName" + cbBonous.SelectedValue.ToString() + "", Connection);
                // Rest of the code...
            }
            else
            {
                // Handle no selection case (optional: display message)
            }
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
            if (cbEmpID.SelectedIndex > -1) // Check if an item is selected
            {
                Connection.Open();
                int selectedBName = int.Parse(cbBonous.SelectedValue.ToString()); // Convert to integer
                SqlCommand cmd = new SqlCommand("Select * from BonousTbl where bonousName = @BName", Connection);
                cmd.Parameters.AddWithValue("@BName", selectedBName); // Use parameter for safe value assignment
                DataTable dataTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0) // Check if data exists for selected ID
                {
                    DataRow dataRow = dataTable.Rows[0];
                    txtBonous.Text = dataRow["bounousAmount"].ToString();
                }
                else
                {
                    // Handle case where no employee found (optional: display message)
                }
            }
            Connection.Close();
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

        // Combo box empID Selection function Calling
        private void cbEmpID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getEmployeedetails();
            getOverTimeDetail();
            getAttendence();
        }

        // Combo Box Bonous Name Selection function calling
        private void cbBonous_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getBonousAmt();
        }

        private void cbAttend_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getAttedenceData();   
        }

        // Salary Calculation 
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

        // Data Add Button Click Event 
        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
