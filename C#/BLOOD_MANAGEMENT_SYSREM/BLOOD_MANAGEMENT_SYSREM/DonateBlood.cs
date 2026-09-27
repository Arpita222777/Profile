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
    public partial class DonateBlood : Form
    {
        public DonateBlood()
        {
            InitializeComponent();
            populate();
            bloodStock();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string Query = "select * from DonorTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DonateBloodDGV.DataSource = ds.Tables[0];



            Con.Close();

        }
        private void bloodStock()
        {
            Con.Open();
            string Query = "select * from BloodTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BloodStockDGV.DataSource = ds.Tables[0];



            Con.Close();

        }

       
        int oldstock;
        private void GetStock(string Bgroup)
        {
            //helps to get the actual stock of blood based on particular blood group
            Con.Open();
            string query = "select * from BloodTb1 where BGroup='" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query,Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda .Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                oldstock = Convert.ToInt32(dr["BStock"].ToString ());

                    }
            Con.Close();

        }
        private void DonateBloodDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DNameTb.Text = DonateBloodDGV.SelectedRows[0].Cells[1].Value.ToString();
            DBGroupCB.Text = DonateBloodDGV.SelectedRows[0].Cells[6].Value.ToString();
            GetStock(DBGroupCB.Text);
        }
        private void Reset()
        {
            DNameTb.Text = "";
            DBGroupCB.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DNameTb.Text == "")
            {
                MessageBox.Show("Select A Domor");
            }else
            {
                try
                {
                    int stock = oldstock+1;
                    string query = "UPDATE BloodTb1 SET BStock=" + stock + "WHERE BGroup='" + DBGroupCB.Text + "';";





                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donation Successfull");
                    Con.Close();

                    Reset();
                    bloodStock();
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    if (Con.State == ConnectionState.Open)
                        Con.Close();
                }

            }
        }

       

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this .Hide();
        }

       

        private void label4_Click(object sender, EventArgs e)
        {
            ViewDonor donor = new ViewDonor();
            donor.Show();
            this .Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            DonateBlood donor = new DonateBlood();
            donor.Show();
            this .Hide();
        }

      
        private void label3_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this .Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Viewpatients viewpatients = new Viewpatients();
            viewpatients.Show();
            this .Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Bloodstock bloodstock = new Bloodstock();
            bloodstock.Show();
            this .Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            BloodTransfer bloodtransfer = new BloodTransfer();
            bloodtransfer.Show();
            this .Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Dashboard_cs dashboard_Cs = new Dashboard_cs();
            dashboard_Cs.Show();
            this .Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this .Hide();
        }
    }
}
