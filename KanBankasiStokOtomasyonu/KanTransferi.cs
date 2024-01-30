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
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using System.Windows.Input;

namespace KanBankasiStokOtomasyonu
{
    public partial class KanTransferi : Form
    {
        public KanTransferi()
        {
            InitializeComponent();
            fillHastaCb();

        }
        static string conn = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(conn);
        private void fillHastaCb()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select HNum from Hastatbl", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("HNum", typeof(int));
            dt.Load(rdr);
            HastaIdCb.ValueMember = "HNum";
            HastaIdCb.DataSource = dt;
            baglanti.Close();
        }
        private void VeriAl() 
        { 
        baglanti.Open();
        string query = "select * from HastaTbl where HNum=" + HastaIdCb.SelectedValue.ToString() + "";
        SqlCommand komut= new SqlCommand(query,baglanti);
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(komut);
        sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                HasAdTb.Text = dr["HAdSoyad"].ToString();
                KanGrupTb.Text = dr["HKGrup"].ToString();
            }
        baglanti.Close();
        }
        int stokk = 0;
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
                stokk = Convert.ToInt32(dr["KStok"].ToString());
            }
            baglanti.Close();
        }
        private void KanTransferi_Load(object sender, EventArgs e)
        {

        }

        private void HastaIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VeriAl();
            Stok(KanGrupTb.Text);
            if (stokk > 0)
            {
                TransferBtn.Visible = true;
                UygunLbl.Text = "Stok uygun";
                UygunLbl.Visible = true;
            }
            else
            {
                UygunLbl.Text = "Stok uygun değil";
                UygunLbl.Visible = true;
                TransferBtn.Visible = false;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Hasta ha= new Hasta();
            ha.Show();
            this.Hide();
        }
        private void Reset()
        {
            HasAdTb.Text = "";
            KanGrupTb.Text = "";
            UygunLbl.Visible= false;
            TransferBtn.Visible= false;
        }
        private void kanGuncelle()
        {
            int yenistok = stokk - 1;
            try
            {
                string query = "update KanTbl set KStok=" + yenistok + " where KGrup='" + KanGrupTb.Text + "';";
                baglanti.Open();
                SqlCommand komut = new SqlCommand(query, baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Reset();                
            }
            catch (Exception Ex)
            {

                MessageBox.Show("Ex.Message");
            }
        }

        private void TransferBtn_Click(object sender, EventArgs e)
        {

            if (HasAdTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "insert into TransferTbl values('" + HasAdTb.Text + "','" + KanGrupTb.Text + "')";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Transfer başarılı");
                    baglanti.Close();
                    Stok(KanGrupTb.Text.ToString());
                    kanGuncelle();
                    Reset();
                }
                
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            KanBagısı kb = new KanBagısı();
            kb.Show();
            this.Hide();
        }

        private void HastaIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            DonorListesi donor = new DonorListesi();
            donor.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            HastaListesi donor1 = new HastaListesi();
            donor1.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            AnaSayfa donor = new AnaSayfa();
            donor.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            KontrolPaneli donor = new KontrolPaneli();
            donor.Show();
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
