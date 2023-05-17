using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmoMillaCosmetics
{
    public partial class fBaslangic : Form
    {
        public fBaslangic()
        {
            InitializeComponent();
        }

        private void bSatisIslemi_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fSatis satis = new fSatis();
            satis.lKullanici.Text = lKullanici.Text;
            satis.ShowDialog();
            Cursor.Current = Cursors.Default;
            
        }

        private void bGenelRapor_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fRapor r = new fRapor();
            r.lKullanici.Text = lKullanici.Text;
            r.ShowDialog();
            Cursor.Current = Cursors.Default;

        }

        private void bStokTakip_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fStok s = new fStok();
            s.lKullanici.Text = lKullanici.Text;
            s.ShowDialog();
            Cursor.Current = Cursors.Default;

        }

        private void bUrunGiris_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fUrunGiris u = new fUrunGiris();
            u.lKullanici.Text = lKullanici.Text;
            u.ShowDialog();
            Cursor.Current = Cursors.Default;

        }

        private void bCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
