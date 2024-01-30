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
using System.Configuration;

namespace KanBankasiStokOtomasyonu
{
    public partial class DonorListesi : Form
    {
        public DonorListesi()
        {
            InitializeComponent();
            uyeler();
        }
        static string conn = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(conn);
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from DonorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DonorDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void DonorListesi_Load(object sender, EventArgs e)
        {

        }

        private void DonorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            AnaSayfa donor1 = new AnaSayfa();
            donor1.Show();
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
            HastaListesi donor2 = new HastaListesi();
            donor2.Show();
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
            KontrolPaneli kontrolPaneli = new KontrolPaneli();
            kontrolPaneli.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
