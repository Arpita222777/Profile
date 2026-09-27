using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BLOOD_MANAGEMENT_SYSREM
{
    public partial class Donor : Form
    {
        public Donor()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void Reset()
        {
            DNameTb.Text = "";
            DAgeTb.Text = "";
            DPhoneTb.Text = "";
            DGenderCb.SelectedIndex = -1;
            DBGroupCB.SelectedIndex= -1;
            DAddressTb.Text = "";
          

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(DNameTb.Text==""|| DPhoneTb.Text=="" || DAgeTb.Text==""|| DGenderCb.SelectedIndex==-1|| DBGroupCB.SelectedIndex==-1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string query = "insert into DonorTb1 VAlues ('" + DNameTb.Text + "'," + DAgeTb.Text + ",'" + DGenderCb.SelectedItem.ToString() + "','" + DPhoneTb.Text + "','" + DAddressTb.Text + "','" + DBGroupCB.SelectedItem.ToString() + "')";
                     Con.Open();
                    SqlCommand cmd =new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donor Successfully Saved");

                    Con.Close();
                    Reset();



                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            DonateBlood donateBlood = new DonateBlood();
            donateBlood.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewDonor viewDonor = new ViewDonor();
            viewDonor.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();                 
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Viewpatients viewpatients = new Viewpatients();
            viewpatients.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Bloodstock bloodstock = new Bloodstock();
            bloodstock.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            BloodTransfer bloodtransfer = new BloodTransfer();
            bloodtransfer.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Dashboard_cs dashboard_Cs = new Dashboard_cs();
            dashboard_Cs.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();
        }
    }
}
