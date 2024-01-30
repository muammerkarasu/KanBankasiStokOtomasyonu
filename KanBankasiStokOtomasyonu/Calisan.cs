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
    public partial class Calisan : Form
    {
        public Calisan()
        {
            InitializeComponent();
            uyeler();
        }
        static string conn = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(conn);

        private void label14_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void Reset()
        {
            CalAdSoyadTb.Text = "";
            CalSifTb.Text = "";
            key = 0;
        }
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from CalisanTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CalisanDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (CalAdSoyadTb.Text == "" || CalSifTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    if (!KullaniciVarMi(CalAdSoyadTb.Text, CalSifTb.Text))
                    {
                        string query = "insert into CalisanTbl values('" + CalAdSoyadTb.Text + "','" + CalSifTb.Text + "' )";
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand(query, baglanti);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Çalışan başarılı bir şekilde kayıt edildi");
                        baglanti.Close();
                        Reset();
                        uyeler();
                    }
                    else
                    {
                        MessageBox.Show("Bu kullanıcı adı veya şifre zaten kullanımda!");
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }
        private bool KullaniciVarMi(string calId, string calSif)
        {
            string query = "select count(*) from CalisanTbl where CalId=@calId or CalSif=@calSif";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(query, baglanti);
            komut.Parameters.AddWithValue("@calId", calId);
            komut.Parameters.AddWithValue("@calSif", calSif);
            int sayac = (int)komut.ExecuteScalar();
            baglanti.Close();
            return sayac > 0;
        }
        int key=0;
        private void CalisanDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CalAdSoyadTb.Text = CalisanDGV.SelectedRows[0].Cells[1].Value.ToString();
            CalSifTb.Text = CalisanDGV.SelectedRows[0].Cells[2].Value.ToString();
            
            if (CalAdSoyadTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CalisanDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek Çalışanı seçiniz");
            }
            else
            {
                try
                {
                    string query = "delete from CalisanTbl where CalNum=" + key + ";";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Çalışan başarılı bir şekilde silindi");
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

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (CalAdSoyadTb.Text == "" || CalSifTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                string yeniCalisanAdSoyad = CalAdSoyadTb.Text;
                string yeniCalisanSifre = CalSifTb.Text;
                foreach (DataGridViewRow row in CalisanDGV.Rows)
                {
                    if (row.Cells[1].Value != null && row.Cells[2].Value != null)
                    {
                        string eskiCalisanAdSoyad = row.Cells[1].Value.ToString();
                        string eskiCalisanSifre = row.Cells[2].Value.ToString();

                        if (yeniCalisanSifre == eskiCalisanSifre)
                        {
                            MessageBox.Show("Girilen şifre zaten mevcut. Farklı bir şifre seçin.");
                            return;
                        }
                    }
                }


                try
                {
                    string query = "update CalisanTbl set CalId='" + CalAdSoyadTb.Text + "',CalSif='" + CalSifTb.Text + "' where CalNum=" + key + ";";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Çalışan başarılı bir şekilde güncellendi");
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
    }
}