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
    public partial class fGelirGider : Form
    {
        public fGelirGider()
        {
            InitializeComponent();
        }

        public string gelirgider { get; set; }
         public string kullanici { get; set; }

        private void fGelirGider_Load(object sender, EventArgs e)
        {
            lGelirGider.Text = gelirgider + " Islemi Yapiliyor ";
        }

        private void cmbOdemeTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
             if(cmbOdemeTuru.SelectedIndex==0)
            {
                tNakit.Enabled = true;
                tKart.Enabled = false;
            }
             if(cmbOdemeTuru.SelectedIndex==1)
            {
                tNakit.Enabled = false;
                tKart.Enabled = true;
            }
             if(cmbOdemeTuru.SelectedIndex==2)
            {
                tNakit.Enabled = true;
                tKart.Enabled = true;
            }
            tNakit.Text = "0";
            tKart.Text = "0";
        }

        private void bEkle_Click(object sender, EventArgs e)
        {
            if()
        }
    }
}
