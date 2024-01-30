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
    public partial class HastaListesi : Form
    {
        public HastaListesi()
        {
            InitializeComponent();
            uyeler();
        }
        static string conn = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(conn);
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from HastaTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            HastaDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        int key = 0;
        private void HastaDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HAdSoyadTb.Text = HastaDGV.SelectedRows[0].Cells[1].Value.ToString();
            HYasTb.Text = HastaDGV.SelectedRows[0].Cells[2].Value.ToString();
            HTelefonTb.Text = HastaDGV.SelectedRows[0].Cells[3].Value.ToString();
            HCinsCb.Text = HastaDGV.SelectedRows[0].Cells[4].Value.ToString();
            HKGrupCb.Text = HastaDGV.SelectedRows[0].Cells[5].Value.ToString();
            HAdresTb.Text = HastaDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (HAdSoyadTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(HastaDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void Reset()
        {
            HAdSoyadTb.Text = "";
            HYasTb.Text = "";
            HCinsCb.SelectedIndex = -1;
            HTelefonTb.Text = "";
            HAdresTb.Text = "";
            HKGrupCb.SelectedIndex = -1;
            key= 0;
        }
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek hastayı seçiniz");
            }
            else
            {
                try
                {
                    string query = "delete from HastaTbl where HNum=" + key + ";";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Hasta başarılı bir şekilde silindi");
                    baglanti.Close();
                    Reset();
                    uyeler();
                }
                catch (Exception Ex)
                {


                    MessageBox.Show("Ex.Message");
                }

            }

        }

        private void label10_Click(object sender, EventArgs e)
        {
            AnaSayfa HL = new AnaSayfa();
            HL.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Hasta ha = new Hasta();
            ha.Show();
            this.Hide();
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
                        string query = "update HastaTbl set HAdSoyad='" + HAdSoyadTb.Text + "', HYas=" + HYasTb.Text + ", HTelefon='" + HTelefonTb.Text + "', HCinsiyet='" + HCinsCb.SelectedItem.ToString() + "', HKGrup='" + HKGrupCb.SelectedItem.ToString() + "', HAdres='" + HAdresTb.Text + "' where HNum=" + key + ";";
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand(query, baglanti);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Hasta başarılı bir şekilde güncellendi");
                        baglanti.Close();
                        Reset();
                        uyeler();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("Ex.Message");
                    }
                }

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            DonorListesi donor1 = new DonorListesi();
            donor1.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            KanBagısı kan=new KanBagısı();
            kan.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            KanTransferi kan1=new KanTransferi();
            kan1.Show();
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
