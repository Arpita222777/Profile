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
    public partial class Dashboard_cs : Form
    {
        public Dashboard_cs()
        {
            InitializeComponent();
            GetData();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetData()
        {
            Con.Open();
            SqlDataAdapter sda=new SqlDataAdapter("Select count(*) from DonorTb1",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DonorLbl.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter sda1 = new SqlDataAdapter("Select count(*) from TransferTb1", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TransferLbl.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter sda2= new SqlDataAdapter("Select count(*) from EmployeeTb1", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            EmployeeLbl.Text = dt2.Rows[0][0].ToString();

            SqlDataAdapter sda3 = new SqlDataAdapter("Select Sum(BStock) from BloodTb1", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            int BStock=Convert.ToInt32(dt3.Rows[0][0].ToString());
            TotalLbl.Text=""+BStock;


            SqlDataAdapter sda4 = new SqlDataAdapter("Select BStock from BloodTb1 where BGroup='"+"O+"+"'", Con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            OplusNumLbl.Text = dt4.Rows[0][0].ToString();
            double OplusPercentage = (Convert.ToDouble(dt4.Rows[0][0]) / BStock) * 100;
            OPlusProgress.Value = Convert.ToInt32(OplusPercentage);

            SqlDataAdapter sda5= new SqlDataAdapter("Select BStock from BloodTb1 where BGroup='"+"AB+"+"'", Con);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            ABPlusLBL.Text = dt5.Rows[0][0].ToString();
            double ABplusPercentage = (Convert.ToDouble(dt4.Rows[0][0]) / BStock) * 100;
            ABPlusProgressLbl.Value = Convert.ToInt32(ABplusPercentage);


            SqlDataAdapter sda6 = new SqlDataAdapter("Select BStock from BloodTb1 where BGroup='"+"O-"+"'", Con);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            ONegLbl.Text = dt6.Rows[0][0].ToString();
            double ONegPercentage = (Convert.ToDouble(dt4.Rows[0][0]) / BStock) * 100;
            ONegProgressLbl.Value = Convert.ToInt32(ONegPercentage);


            SqlDataAdapter sda7 = new SqlDataAdapter("Select BStock from BloodTb1 where BGroup='" + "AB-" + "'", Con);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
              ABPNegLbl.Text = dt7.Rows[0][0].ToString();
            double  ABPpercentage= (Convert.ToDouble(dt4.Rows[0][0]) / BStock) * 100;
            ABNegProgressLbl.Value = Convert.ToInt32(ABPpercentage);

            // MessageBox.Show("" + OplusPercentage);

            Con.Close();

        }
        
       

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            DonateBlood donateBlood = new DonateBlood();
            donateBlood.Show();
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

        private void label5_Click(object sender, EventArgs e)
        {
            Viewpatients Vw=new Viewpatients();
            Vw.Show();
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

    
    }
}
