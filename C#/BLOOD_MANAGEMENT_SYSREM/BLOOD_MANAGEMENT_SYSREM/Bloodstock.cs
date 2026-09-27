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
    public partial class Bloodstock : Form
    {
        public Bloodstock()
        {
            InitializeComponent();
            bloodStock();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\BloodBankDB.mdf;Integrated Security=True;Connect Timeout=30");
      
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Bloodstock_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor db = new Donor();
            db.Show();
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
            ViewDonor donateBlood1= new ViewDonor();
            donateBlood1.Show();
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

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

       private void label16_Click(object sender, EventArgs e)
{
    try
    {
        Con.Open();
        string Query = "SELECT * FROM BloodTb1 WHERE BGroup = @BGroup";
        SqlDataAdapter sda = new SqlDataAdapter(Query, Con);

        // ✅ Use SelectedItem for ComboBox
        if (DBGroupCB.SelectedItem != null)
        {
            sda.SelectCommand.Parameters.AddWithValue("@BGroup", DBGroupCB.SelectedItem.ToString().Trim());
        }
        else
        {
            MessageBox.Show("Please select a blood group.");
            return;
        }

        DataSet ds = new DataSet();
        sda.Fill(ds);
        BloodStockDGV.DataSource = ds.Tables[0];
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error: " + ex.Message);
    }
    finally
    {
        Con.Close();
    }
}

        private void label7_Click_1(object sender, EventArgs e)
        {
            BloodTransfer Bt = new BloodTransfer();
            Bt.Show();
            this.Hide();
        }

        private void label8_Click_1(object sender, EventArgs e)
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
