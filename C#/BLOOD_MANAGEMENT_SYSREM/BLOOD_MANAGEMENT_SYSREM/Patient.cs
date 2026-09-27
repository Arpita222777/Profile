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
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        // Database Connection
        SqlConnection Con = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              AttachDbFilename=C:\Users\User\Documents\BloodBankDB.mdf;
              Integrated Security=True;Connect Timeout=30");

        // Reset input fields
        private void Reset()
        {
            PName.Text = "";
            PAge.Text = "";
            PPhone.Text = "";
            PGenCb.SelectedIndex = -1;
            PBGroupCb.SelectedIndex = -1;
            PAdressTb.Text = "";
        }

        // Save Button
        private void button1_Click(object sender, EventArgs e)
        {
            if (PName.Text == "" || PPhone.Text == "" || PAge.Text == "" ||
                PGenCb.SelectedIndex == -1 || PBGroupCb.SelectedIndex == -1 ||
                PAdressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    // ✅ Fixed concatenation query
                    string query = "INSERT INTO PatientTb1 VALUES ('"
                        + PName.Text + "',"
                        + PAge.Text + ",'"
                        + PPhone.Text + "','"
                        + PGenCb.SelectedItem.ToString() + "','"
                        + PBGroupCb.SelectedItem.ToString() + "','"
                        + PAdressTb.Text + "')";

                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Saved");
                    Con.Close();

                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    if (Con.State == ConnectionState.Open)
                        Con.Close();
                }
            }
        }

        private void Patient_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Viewpatients vp = new Viewpatients();
            vp.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            BloodTransfer Bt = new BloodTransfer();
            Bt.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            DonateBlood Db = new DonateBlood();
            Db.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewDonor donor = new ViewDonor();
            donor.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Bloodstock bloodstock = new Bloodstock();
            bloodstock.Show();
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
    }
}
