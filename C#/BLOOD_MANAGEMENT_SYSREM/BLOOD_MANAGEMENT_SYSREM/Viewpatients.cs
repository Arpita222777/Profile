using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLOOD_MANAGEMENT_SYSREM
{
    public partial class Viewpatients : Form
    {
        public Viewpatients()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30");
       
        private void populate()
        {
            Con.Open();
            string Query = "select * from PatientTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PatientsDGV.DataSource = ds.Tables[0];



            Con.Close();

        }
        int key = 0;
        private void PatientsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PNameTb.Text = PatientsDGV.SelectedRows[0].Cells[1].Value.ToString();
            PAgeTb.Text = PatientsDGV.SelectedRows[0].Cells[2].Value.ToString();

            PphoneTb.Text = PatientsDGV.SelectedRows[0].Cells[3].Value.ToString();
            PGenCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[4].Value.ToString();

            PBGroupCb.SelectedItem = PatientsDGV.SelectedRows[0].Cells[5].Value.ToString();
            PAddressTb.Text = PatientsDGV.SelectedRows[0].Cells[6].Value.ToString();

            if (PNameTb.Text == "")
            {
                key = 0;
            }else
            {
                key = Convert.ToInt32(PatientsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void Reset()
        {
            PNameTb.Text = "";
            PAgeTb.Text = "";
            PphoneTb.Text = "";
            PGenCb.SelectedIndex = -1;
            PBGroupCb.SelectedIndex = -1;
            PAddressTb.Text = "";
            key = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the Patient to Delete");
            }
            else
            {
                try
                {
                    string query = "Delete from PatientTb1 where PNum=" + key + ";";

                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Deleted");
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

        private void Viewpatients_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PNameTb.Text == "" || PphoneTb.Text == "" || PAgeTb.Text == "" ||
                PGenCb.SelectedIndex == -1 || PBGroupCb.SelectedIndex == -1 ||
                PAddressTb.Text == "")
            {
                MessageBox.Show("Missing Information ");
            }
            else
            {
                try
                {
                    string query = "UPDATE PatientTb1 SET "
                                                      + "PName='" + PNameTb.Text + "', "
                                                        + "PAge=" + PAgeTb.Text + ", "
                                                          + "PPhone='" + PphoneTb.Text + "', "
                                                              + "PGender='" + PGenCb.SelectedItem.ToString() + "', "
                                                                 + "PBGroup='" + PBGroupCb.SelectedItem.ToString() + "', "
                                                                     + "PAddress='" + PAddressTb.Text + "' "
                                                                         + "WHERE PNum=" + key + ";";

                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Updated");
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

        private void label3_Click(object sender, EventArgs e)
        {
            Patient Pat =new Patient();
            Pat.Show();
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
            DonateBlood donateBlood = new DonateBlood();
                donateBlood .Show();    
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewDonor donor = new ViewDonor();
            donor.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Viewpatients viewpatients = new Viewpatients();
            viewpatients .Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
           Bloodstock bloodstock = new Bloodstock();
            bloodstock .Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            BloodTransfer bloodTransfer = new BloodTransfer();
            bloodTransfer .Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Dashboard_cs dashboard_Cs = new Dashboard_cs();

            dashboard_Cs .Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login .Show();
            this.Hide();
        }

       
    }
}
