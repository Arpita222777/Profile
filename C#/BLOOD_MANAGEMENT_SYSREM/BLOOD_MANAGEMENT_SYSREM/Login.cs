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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void label4_Click(object sender, EventArgs e)
        {
            AdminLogin Adm=new AdminLogin();
            Adm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda=new SqlDataAdapter("select count(*) from EmployeeTb1 where EmpName='"+EmpNameTb.Text+"'and EmpPass='"+EmpPassTb.Text+"'",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Mainform Main=new Mainform();
                Main.Show();
                this.Hide();
                Con.Close();


            }
            else
            {
                MessageBox.Show("Wrong UserName or Password");
            }
                Con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();                             
        }
    }
}
