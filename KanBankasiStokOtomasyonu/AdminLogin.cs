using Guna.UI2.WinForms;
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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }
        static string conn = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        SqlConnection cont = new SqlConnection(conn); 
        public bool emptyFields()
        {
            if (AdminSifreTb.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void SifreTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
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
                        
                        string selectAccount = "SELECT * FROM users WHERE Eposta = @eposta AND Sifre = @pass ";

                        using (SqlCommand cmd = new SqlCommand(selectAccount, cont))
                        {
                           
                            cmd.Parameters.AddWithValue("@pass", AdminSifreTb.Text.Trim());

                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                Calisan calisan = new Calisan();
                calisan.Show();
                this.Hide();
            }
        }
         private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DogrulamaEkrani sifremi = new DogrulamaEkrani();
            sifremi.Show();
            this.Hide();
        }

        private void txt_sifre_CheckedChanged(object sender, EventArgs e)
        {
            AdminSifreTb.PasswordChar = AdminSifreTb.PasswordChar == '\0' ? '*' : '\0';
        }
    }
}
