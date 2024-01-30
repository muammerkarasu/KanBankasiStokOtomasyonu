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
using System.Windows.Input;
using System.Configuration;

namespace KanBankasiStokOtomasyonu
{
    public partial class KanBagısı : Form
    {
        public KanBagısı()
        {
            InitializeComponent();
            uyeler();
            KanStok();
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
            KBagısıDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void KanStok()
        {
            baglanti.Open();
            string query = "select *from KanTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            KStoguDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void DYasTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void KanBagısı_Load(object sender, EventArgs e)
        {

        }

        private void KBagısıDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DAdSoyadTb.Text = KBagısıDGV.SelectedRows[0].Cells[1].Value.ToString();
            DKGrubuTb.Text = KBagısıDGV.SelectedRows[0].Cells[6].Value.ToString();
            Stok(DKGrubuTb.Text);
        }
        private void Reset()
        {
            DAdSoyadTb.Text = "";
            DKGrubuTb. Text = "";
        }

            private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (DAdSoyadTb.Text == "")
{
                MessageBox.Show("Bir Donor Seçiniz");
            }
            else
            {
                try
                {
                    int stok = eskistok+1;
                    string query = "update KanTbl set KStok='" + stok + "' where KGrup='" + DKGrubuTb.Text + "';";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Bağış Başarılı ");
                    baglanti.Close();
                    Reset();
                    KanStok();
                }
                catch (Exception Ex)
                {


                    MessageBox.Show("Ex.Message");
                }

            }
        }

        private void KStoguDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int eskistok;
        private void Stok(string Kgrup)
        {
            baglanti.Open();
            string query = "select * from KanTbl where KGrup='" + Kgrup + "'";
            SqlCommand komut = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                eskistok = Convert.ToInt32(dr["KStok"].ToString());
            }
            baglanti.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            AnaSayfa kt = new AnaSayfa();
            kt.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            DonorListesi kt = new DonorListesi();
            kt.Show();
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
            HastaListesi kt = new HastaListesi();
            kt.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            KanTransferi kt = new KanTransferi();
            kt.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            KontrolPaneli kt = new KontrolPaneli();
            kt.Show();
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
