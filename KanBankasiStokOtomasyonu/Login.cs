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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        static string conn = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(conn);
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter sda= new SqlDataAdapter("select count (*) from CalisanTbl where CalId ='"+KullaniciTb.Text+"' and CalSif='"+SifreTb.Text+"'",baglanti);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString()== "1" )
            {
                AnaSayfa anaSayfa = new AnaSayfa();
                anaSayfa.Show();
                this.Hide();
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Yanlış Şifre veya Kullanıcı");
            }
            baglanti.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminLogin adm=new AdminLogin();
            adm.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SifreTb.PasswordChar = SifreTb.PasswordChar == '\0' ? '*' : '\0';
        }

        private void KullaniciTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void SifreTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
