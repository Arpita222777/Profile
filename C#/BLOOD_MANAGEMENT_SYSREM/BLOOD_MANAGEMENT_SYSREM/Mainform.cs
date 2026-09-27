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
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log=new Login();
            log.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donor=new Donor();
            donor.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            DonateBlood db = new DonateBlood();
            db.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewDonor VD=new ViewDonor();
            VD.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Patient patient=new Patient();
            patient.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Viewpatients viewpatients=new Viewpatients();
            viewpatients.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Bloodstock bloodstock=new Bloodstock();
            bloodstock.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            BloodTransfer bloodTransfer=new BloodTransfer();
               bloodTransfer.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Dashboard_cs dashboard_Cs=new Dashboard_cs();
            dashboard_Cs.Show();
            this.Hide();
        }
    }
}
