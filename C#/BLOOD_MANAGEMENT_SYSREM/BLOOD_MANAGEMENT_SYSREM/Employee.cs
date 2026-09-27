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

namespace BLOOD_MANAGEMENT_SYSREM
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void Reset()
        {
            EmpNameTb.Text = "";
            EmpPassTb.Text = "";
            key = 0;
        }
        private void populate()
        {
            Con.Open();
            string Query = "select * from EmployeeTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeeDGV.DataSource = ds.Tables[0];



            Con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpPassTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string query = "INSERT INTO EmployeeTb1 VALUES ('" + EmpNameTb.Text + "', '" + EmpPassTb.Text + "')";



                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Emplyee Successfully Saved");

                    Con.Close();
                    Reset();
                    populate();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpPassTb.Text = EmployeeDGV.SelectedRows[0].Cells[2].Value.ToString();



            if (EmpNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(EmployeeDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (key == 0)
            {
                MessageBox.Show("Select the Employee to Delete");
            }
            else
            {
                try
                {
                    string query = "Delete from EmployeeTb1 where EmpNum=" + key + ";";

                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Deleted");
                    Con.Close();

                    Reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    if (Con.State == ConnectionState.Open)
                        Con.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpPassTb.Text == "")


            {
                MessageBox.Show("Missing Information ");
            }
            else
            {
                try
                {
                    string query = "UPDATE EmployeeTb1 SET EmpName='" + EmpNameTb.Text + "', EmpPass='" + EmpPassTb.Text +  "' WHERE EmpNum=" + key + ";";





                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee  Successfully Updated");
                    Con.Close();

                    Reset();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    if (Con.State == ConnectionState.Open)
                        Con.Close();
                }
            }
        }
    }
} 