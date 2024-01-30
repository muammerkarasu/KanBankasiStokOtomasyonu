using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanBankasiStokOtomasyonu
{
    public partial class KontrolPaneli : Form
    {
        public KontrolPaneli()
        {
            InitializeComponent();
            VeriCek();

        }
        static string conn = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(conn);
        private void VeriCek()
        {
            baglanti.Open();
            SqlDataAdapter sda= new SqlDataAdapter("select count (*) from DonorTbl ", baglanti);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DonorLbl.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sda1 = new SqlDataAdapter("select count (*) from TransferTbl ", baglanti);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TransferLbl.Text = dt1.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("select count (*) from CalisanTbl ", baglanti);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            KullaniciLbl.Text = dt2.Rows[0][0].ToString();
            SqlDataAdapter sda3 = new SqlDataAdapter("select count (*) from KanTbl ", baglanti);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            int Kstok = Convert.ToInt32(dt3.Rows[0][0].ToString());
            TotalLbl.Text = "" + Kstok;
            
            SqlDataAdapter sda4 = new SqlDataAdapter("select KStok from KanTbl where KGrup='"+"0+"+"' ", baglanti);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            Num.Text = dt4.Rows[0][0].ToString();
            double OplusPercentage = (Convert.ToDouble(dt4.Rows[0][0].ToString())/Kstok) * 100;
            OplusBar.Value = Convert.ToInt32(OplusPercentage);
            SqlDataAdapter sda5 = new SqlDataAdapter("select KStok from KanTbl where KGrup='" + "0-" + "' ", baglanti);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            Num1.Text = dt5.Rows[0][0].ToString();
            double OnPercentage = (Convert.ToDouble(dt5.Rows[0][0].ToString()) / Kstok) * 100;
            OminBar.Value = Convert.ToInt32(OnPercentage);

            SqlDataAdapter sda6 = new SqlDataAdapter("select KStok from KanTbl where KGrup='" + "AB+" + "' ", baglanti);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            AB1.Text = dt6.Rows[0][0].ToString();
            double ABplusPercentage = (Convert.ToDouble(dt6.Rows[0][0].ToString()) / Kstok) * 100;
            ABplusBar.Value = Convert.ToInt32(ABplusPercentage);
            SqlDataAdapter sda7 = new SqlDataAdapter("select KStok from KanTbl where KGrup='" + "AB-" + "' ", baglanti);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
            AB2.Text = dt7.Rows[0][0].ToString();
            double ABnPercentage = (Convert.ToDouble(dt7.Rows[0][0].ToString()) / Kstok) * 100;
            ABminBar.Value = Convert.ToInt32(ABnPercentage);

            SqlDataAdapter sda8 = new SqlDataAdapter("select KStok from KanTbl where KGrup='" + "B+" + "' ", baglanti);
            DataTable dt8 = new DataTable();
            sda8.Fill(dt8);
            B1.Text = dt8.Rows[0][0].ToString();
            double BplusPercentage = (Convert.ToDouble(dt8.Rows[0][0].ToString()) / Kstok) * 100;
            BplusBar.Value = Convert.ToInt32(BplusPercentage);
            SqlDataAdapter sda9 = new SqlDataAdapter("select KStok from KanTbl where KGrup='" + "B-" + "' ", baglanti);
            DataTable dt9 = new DataTable();
            sda9.Fill(dt9);
            B2.Text = dt9.Rows[0][0].ToString();
            double BnPercentage = (Convert.ToDouble(dt9.Rows[0][0].ToString()) / Kstok) * 100;
            BminBar.Value = Convert.ToInt32(BnPercentage);

            SqlDataAdapter sda10 = new SqlDataAdapter("select KStok from KanTbl where KGrup='" + "A+" + "' ", baglanti);
            DataTable dt10 = new DataTable();
            sda10.Fill(dt10);
            A1.Text = dt10.Rows[0][0].ToString();
            double AplusPercentage = (Convert.ToDouble(dt10.Rows[0][0].ToString()) / Kstok) * 100;
            AplusBar.Value = Convert.ToInt32(AplusPercentage);
            SqlDataAdapter sda11 = new SqlDataAdapter("select KStok from KanTbl where KGrup='" + "A-" + "' ", baglanti);
            DataTable dt11 = new DataTable();
            sda11.Fill(dt11);
            A2.Text = dt11.Rows[0][0].ToString();
            double AnPercentage = (Convert.ToDouble(dt11.Rows[0][0].ToString()) / Kstok) * 100;
            AminBar.Value = Convert.ToInt32(AnPercentage);
            baglanti.Close();

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void KontrolPaneli_Load(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void TotalLbl_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            DonorListesi donorListesi = new DonorListesi();
            donorListesi.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Hasta hasta = new Hasta();
            hasta.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            HastaListesi don=new HastaListesi();
            don.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            KanBagısı kanBagısı= new KanBagısı();
            kanBagısı.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            KanTransferi kanTransferi = new KanTransferi();
            kanTransferi.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            AnaSayfa kontrolPaneli = new AnaSayfa();
            kontrolPaneli.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ABplusBar_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
