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
    public partial class BloodTransfer : Form
    {
        public BloodTransfer()
        {
            InitializeComponent();
            fillPatientCb();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillPatientCb()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select PNum from PatientTb1 ", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PNum",typeof(int ));
            dt.Load(rdr);
            PatientIdCb.ValueMember = "PNum";
            PatientIdCb.DataSource= dt;

            Con.Close();
        }
        private void GetData()
        {
            //helps to get the Blood group and patient nasme o
            Con.Open();
            string query = "select * from PatientTb1 where PNum=" + PatientIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                PatNameTb.Text = dr["PName"].ToString();
                BloodGroupTb.Text = dr["PBGroup"].ToString();

            }
            Con.Close();

        }
        int stock=0;
        private void GetStock(string Bgroup)
        {
            //helps to get the actual stock of blood based on particular blood group
            Con.Open();
            string query = "select * from BloodTb1 where BGroup='" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                stock = Convert.ToInt32(dr["BStock"].ToString());

            }
            Con.Close();

        }
        /*
        int oldstock;
        private void GetStock(string Bgroup)
        {
            //helps to get the actual stock of blood based on particular blood group
            Con.Open();
            string query = "select * from BloodTb1 where BGroup='" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                oldstock = Convert.ToInt32(dr["BStock"].ToString());

            }
            Con.Close();

        }
        */
        private void PatientIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetData();
            GetStock(BloodGroupTb.Text);
            if(stock>0)
            {
                TransferBtn.Visible =true;
                AvailableLbl.Text = "Available Stock";
                AvailableLbl.Visible = true;
            }
            else
            {

                TransferBtn.Visible = false;//this is not int he tutoriual
                AvailableLbl.Text = "Stock not Available";
                AvailableLbl.Visible = true;
            }
        }

        private void BloodTransfer_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            this.Hide();
        }
        private void Reset()
        {
            PatNameTb.Text = "";
            //  PatientIdCb.SelectedIndex = -1;
            BloodGroupTb.Text = "";
            AvailableLbl.Visible=false;
            TransferBtn.Visible=false;

        }
        private void updateStock()
        {
            int newstock = stock-1;
            try
            {
                string query = "update BloodTb1 set BStock=" + newstock + "where BGroup='" + BloodGroupTb.Text+"';";
                                                  
                                                  

                Con.Open();
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Patient Successfully Updated");
                Con.Close();

               
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
               
            }
        }
        
        private void TransferBtn_Click(object sender, EventArgs e)
        {
            if (PatNameTb.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string query = "insert into TransferTb1 VAlues ('" + PatNameTb.Text + "','" + BloodGroupTb.Text + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Transfer ");

                    Con.Close();
                    GetStock(BloodGroupTb.Text);
                    updateStock();
                    Reset();
                    


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Bloodstock Bstock= new Bloodstock();
            Bstock.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donor= new Donor();
            donor.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            DonateBlood donateBlood= new DonateBlood();
            donateBlood.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewDonor donateBlood= new ViewDonor();
            donateBlood.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Viewpatients viewpatients= new Viewpatients();
            viewpatients.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            BloodTransfer bloodTransfer= new BloodTransfer();
                bloodTransfer.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Dashboard_cs dashboard_Cs= new Dashboard_cs();
            dashboard_Cs.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login login= new Login();
            login.Show();
            this.Hide();
        }
    }
}
