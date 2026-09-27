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
    public partial class ViewDonor : Form
    {
        public ViewDonor()
        {
            InitializeComponent();
            populate();
        }

        SqlConnection Con = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            try
            {
                Con.Open();
                string Query = "SELECT * FROM DonorTb1";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DonorDGV.DataSource = ds.Tables[0];
            }
            finally
            {
                Con.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            DonateBlood donateBlood = new DonateBlood();
            donateBlood.Show();
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

        // ❌ Removed BloodTransfer from panel1_Paint (causing auto redirect)
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Leave empty (this event is for drawing, not navigation)
        }

        // ✅ Correct way: open BloodTransfer using a label click
        private void label7_Click(object sender, EventArgs e)
        {
            BloodTransfer bloodTransfer = new BloodTransfer();
            bloodTransfer.Show();
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

        private void label4_Click(object sender, EventArgs e)
        {
            // Instead of reopening ViewDonor inside itself,
            // just refresh the donor list
            populate();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void ViewDonor_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
