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
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }
        static string conn = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        SqlConnection cont = new SqlConnection(conn);
        public bool emptyFields()
        {
            if (guna2TextBox1.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string email = DogrulamaEkrani.to;


            if (emptyFields())
            {
                MessageBox.Show("Lütfen bütün boşlukları doldurun", "işlem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string password = guna2TextBox1.Text;
                string password2 = guna2TextBox2.Text;
                if (password != password2)
                {
                    MessageBox.Show("Girdiğiniz şifreler uyuşmuyor", "Durum", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (password == password2)
                {
                    if (cont.State == ConnectionState.Closed)
                    {
                        try
                        {
                            cont.Open();
                            string sifreyenile = "update giriss set Sifre='" + password + "'Where Eposta='" + email + "'";
                            using (SqlCommand cmd = new SqlCommand(sifreyenile, cont))
                            {
                                cmd.ExecuteNonQuery();
                                cont.Close();
                                MessageBox.Show("Şifreniz başarıyla değiştirildi", "Durum", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MessageBox.Show("Lütfen giriş yapınız", "Durum", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                AdminLogin login = new AdminLogin();
                                login.Show();
                                this.Hide();

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Bağlantı başarısız oldu: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            cont.Close();

                        }
                    }
                }
            }
        }
    }
}
