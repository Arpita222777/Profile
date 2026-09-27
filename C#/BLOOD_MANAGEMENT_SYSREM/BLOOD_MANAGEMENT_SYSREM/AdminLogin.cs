using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLOOD_MANAGEMENT_SYSREM
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AdminPassTb.Text == "")
            {
                MessageBox.Show("Enter the Admin Password ");
            }
            else if(AdminPassTb.Text == "Password")
            {
                Employee Emp = new Employee();
                Emp.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrong PassWord .Contact the System Admin");
                AdminPassTb.Text = "";
            }
        }
    }
}
