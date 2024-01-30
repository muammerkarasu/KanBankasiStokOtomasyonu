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
    public partial class Hasta : Form
    {
        public Hasta()
        {
            InitializeComponent();
        }

        static string conn = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(conn);
        private void Reset()
        {
            HAdSoyadTb.Text = "";
            HYasTb.Text = "";
            HCinsCb.SelectedIndex = -1;
            HTelefonTb.Text = "";
            HAdresTb.Text = "";
            HKGrupCb.SelectedIndex = -1;
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (HAdSoyadTb.Text == "" || HYasTb.Text == "" || HCinsCb.SelectedIndex == -1 || HTelefonTb.Text == "" || HKGrupCb.SelectedIndex == -1 || HAdresTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    if (!KullaniciVeTelefonKontrol(HAdSoyadTb.Text, HTelefonTb.Text))
                    {
                        string query = "insert into HastaTbl values('" + HAdSoyadTb.Text + "'," + HYasTb.Text + ",'" + HTelefonTb.Text + "','" + HCinsCb.SelectedItem.ToString() + "','" + HKGrupCb.SelectedItem.ToString() + "','" + HAdresTb.Text + "')";
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand(query, baglanti);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Hasta başarılı bir şekilde kayıt edildi");
                        baglanti.Close();
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Bu kullanıcı adı ve telefon numarası zaten kullanımda!");
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private bool KullaniciVeTelefonKontrol(string adSoyad, string telefon)
        {
            string query = "select count(*) from HastaTbl where HAdSoyad=@adSoyad or HTelefon=@telefon";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(query, baglanti);
            komut.Parameters.AddWithValue("@adSoyad", adSoyad);
            komut.Parameters.AddWithValue("@telefon", telefon);
            int sayac = (int)komut.ExecuteScalar();
            baglanti.Close();
            return sayac > 0;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            HastaListesi HL = new HastaListesi();
            HL.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            KanTransferi Kan = new KanTransferi();
            Kan.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            AnaSayfa hasta = new AnaSayfa();
            hasta.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            DonorListesi donor = new DonorListesi();
            donor.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            KanBagısı kanBagısı=new KanBagısı();
            kanBagısı.Show();
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
