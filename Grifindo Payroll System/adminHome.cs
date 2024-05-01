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
using Grifindo_Payroll_System.adminPages;
using Grifindo_Payroll_System.Pages;

namespace Grifindo_Payroll_System
{
    public partial class adminHome : KryptonForm
    {
        public adminHome()
        {
            InitializeComponent();
            countEmployee();
            countManager();
            countToys();
            sumSalary();
            sumBonous();
        }

        // Sql Data Connection
        private SqlConnection Connection = new SqlConnection("Data Source=TUF-GAMING-F15\\SQLEXPRESS;Initial Catalog=GrifindoToys;Integrated Security=True;Encrypt=False");
        // Sql Data Connection


        // Employee Count 
        private void countEmployee()
        {
            try
            {
                // Open database connection
                Connection.Open();

                // Create SQL command to count employees
                string query = "SELECT COUNT(*) AS EmployeeCount FROM EmployeeTbl";
                SqlCommand cmd = new SqlCommand(query, Connection);

                // Execute the command and get the employee count
                int employeeCount = (int)cmd.ExecuteScalar();

                // Update the UI element to display the count
                empNUM.Text = $"{employeeCount}";

                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting employee count: {ex.Message}");
            }
        }


        // Managers Count
        private void countManager()
        {
            try
            {
                // Open database connection
                Connection.Open();

                // Create SQL command to count employees
                string query = "SELECT COUNT(*) AS ManagerCount FROM MangerTbl";
                SqlCommand cmd = new SqlCommand(query, Connection);

                // Execute the command and get the employee count
                int managerCount = (int)cmd.ExecuteScalar();

                // Update the UI element to display the count
                mngNUM.Text = $"{managerCount}";

                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting Manager count: {ex.Message}");
            }
        }


        // Toys Count
        private void countToys()
        {
            try
            {
                // Open database connection
                Connection.Open();

                // Create SQL command to count employees
                string query = "SELECT COUNT(*) AS ToysCount FROM ToyRegTbl";
                SqlCommand cmd = new SqlCommand(query, Connection);

                // Execute the command and get the employee count
                int toysCount = (int)cmd.ExecuteScalar();

                // Update the UI element to display the count
                toyNUM.Text = $"{toysCount}";

                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting toys count: {ex.Message}");
            }
        }


        // sum of total Salary 
        private void sumSalary()
        {
            try
            {
                // Open database connection
                Connection.Open();

                // Create SQL command to sum total paid salary
                string query = "SELECT SUM(empBalance) AS TotalPaidSalary FROM SalaryTbl";
                SqlCommand cmd = new SqlCommand(query, Connection);

                // Execute the command and get the total salary
                decimal totalPaidSalary = Convert.ToDecimal(cmd.ExecuteScalar());

                // Update the UI element to display the total (replace totalSalaryLabel with your actual label control)
                salaryNo.Text = $"LKR {totalPaidSalary:#,##0.00}"; // Format as currency

                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting total paid salary: {ex.Message}");
            }
        }


        // Sum of total Bonous
        private void sumBonous()
        {
            try
            {
                // Open database connection
                Connection.Open();

                // Create SQL command to sum total paid salary
                string query = "SELECT SUM(bounousAmount) AS TotalBonous FROM BonousTbl";
                SqlCommand cmd = new SqlCommand(query, Connection);

                // Execute the command and get the total salary
                decimal totalBonous = Convert.ToDecimal(cmd.ExecuteScalar());

                // Update the UI element to display the total (replace totalSalaryLabel with your actual label control)
                txtBonous.Text = $"LKR {totalBonous:#,##0.00}"; // Format as currency

                Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting total Bonous: {ex.Message}");
            }
        }

        private void mgmtoyPIC_Click(object sender, EventArgs e)
        {
            Bonous bonous = new Bonous();
            bonous.Show();
        }

        private void mngrPIC_Click(object sender, EventArgs e)
        {
            Managers managers = new Managers();
            managers.Show();
        }

        private void empPIC_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Attendance attendance = new Attendance();
            attendance.Show();
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
    }
}
