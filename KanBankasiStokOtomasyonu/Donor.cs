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
    public partial class Donor : Form
    {
        public Donor()
        {
            InitializeComponent();
        }
        static string conn = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(conn);
        private void Reset() {
            DAdSoyadTb.Text ="";
            DYasTb.Text ="";
            DCinsCb.SelectedIndex = -1;
            DTelefonTb.Text = "";
            DAdresTb.Text = "";
            DKGrupCb.SelectedIndex = -1;
        }


        private void Donor_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
            if (DAdSoyadTb.Text == "" || DYasTb.Text == "" || DCinsCb.SelectedIndex == -1 || DTelefonTb.Text == "" || DKGrupCb.SelectedIndex == -1 || DAdresTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    if (!DonorAdiVeTelefonKontrol(DAdSoyadTb.Text, DTelefonTb.Text))
                    {
                        string query = "insert into DonorTbl values('" + DAdSoyadTb.Text + "'," + DYasTb.Text + ",'" + DCinsCb.SelectedItem.ToString() + "','" + DTelefonTb.Text + "','" + DAdresTb.Text + "','" + DKGrupCb.SelectedItem.ToString() + "')";
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand(query, baglanti);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Donor başarılı bir şekilde kayıt edildi");
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
        private bool DonorAdiVeTelefonKontrol(string adSoyad, string telefon)
        {
            string query = "select count(*) from DonorTbl where DAdSoyad=@adSoyad or DTelefon=@telefon";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(query, baglanti);
            komut.Parameters.AddWithValue("@adSoyad", adSoyad);
            komut.Parameters.AddWithValue("@telefon", telefon);
            int sayac = (int)komut.ExecuteScalar();
            baglanti.Close();
            return sayac > 0;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            DonorListesi dl = new DonorListesi();   
            dl.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Hasta h = new Hasta();
            h.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            HastaListesi hl = new HastaListesi();
            hl.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            KanBagısı kb = new KanBagısı();
            kb.Show();
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
            KontrolPaneli kp = new KontrolPaneli();
            kp.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            AnaSayfa donor = new AnaSayfa();
            donor.Show();
            this.Hide();
        }
    }
}
