using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Guna.UI2.WinForms;
using System.Configuration;

namespace KanBankasiStokOtomasyonu
{
    public partial class DogrulamaEkrani : Form
    {
        public DogrulamaEkrani()
        {
            InitializeComponent();
        }
        static string conn = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        SqlConnection cont = new SqlConnection(conn);
        SqlDataReader dr;
        string randomcode;
        public static string to;
        public bool emptyFields()
        {
            if (guna2TextBox1.Text == "")
            {                
                return true;
            }else
            {
                return false;
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (randomcode == guna2TextBox2.Text)
            {
                SifremiUnuttum sifre = new SifremiUnuttum();
                sifre.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Doğrulama Kodu Yanlış. Lütfen Kontrol Ediniz !");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AdminLogin login = new AdminLogin();
            login.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Lütfen bütün boşlukları doldurun", "işlem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {


                if (cont.State == ConnectionState.Closed)
                {
                    try
                    {
                        cont.Open();
                        string eposta_arama = "select * from giriss Where Eposta='" + guna2TextBox1.Text + "'";
                        using (SqlCommand cmd = new SqlCommand(eposta_arama, cont))
                        dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            string from, pass, messagebody;
                            Random rand = new Random();
                            randomcode = (rand.Next(999999)).ToString();
                            MailMessage message = new MailMessage();
                            to = (guna2TextBox1.Text).ToString();
                            from = "";//buraya E-posta göndereceğiniz adresi giriniz
                            pass = "";// burayada 3.parti yazılımlar için gereken şifrenizi
                            messagebody = $"Hoş geldiniz {randomcode} kodunu kullanarak devam edebilirsiniz.";
                            message.To.Add(to);
                            message.From = new MailAddress(from);
                            message.Body = messagebody;
                            message.Subject = "Password Rest Code";
                            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                            smtp.EnableSsl = true;
                            smtp.Port = 587;
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.Credentials = new NetworkCredential(from, pass);
                            try
                            {

                                smtp.Send(message);
                                
                                MessageBox.Show("Kodu Başarıyla Gönderildi", "Durum ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                            MessageBox.Show("lütfen mailinizi kontrol ediniz!");
                        cont.Close();
                    }
                    catch (Exception ex) { MessageBox.Show("Bağlantı başarısız oldu: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    finally
                    {
                        cont.Close();
                        
                    }
                }
            }
        }
    }
    
}
