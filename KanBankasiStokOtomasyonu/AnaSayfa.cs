using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanBankasiStokOtomasyonu
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            DonorListesi don=new DonorListesi();
            don.Show();
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
            HastaListesi hl = new HastaListesi();
            hl.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            KanBagısı kb=new KanBagısı();
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
            Login Lg = new Login();
            Lg.Show();
            this.Hide();
        }

        private void kanGruplarıToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Vizyonumuz vizyonumuz = new Vizyonumuz();
            vizyonumuz.Show();
            this.Hide();
        }

        private void vizyonumuzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vizyonumuz vizyonumuz = new Vizyonumuz();
            vizyonumuz.Show();
            this.Hide();
        }

        private void alternatifKanGruplarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alternatifler l=new Alternatifler();
            l.Show();
            this.Hide();
        }

        private void mENÜToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
