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
    public partial class fUrunGrubuEkle : Form
    {
        public fUrunGrubuEkle()
        {
            InitializeComponent();
        }

        BarkodDbEntities db = new BarkodDbEntities();
        private void fUrunGrubuEkle_Load(object sender, EventArgs e)
        {
            GrupDoldur();
        }

        private void bEkle_Click(object sender, EventArgs e)
        {
            if(tUrunGrupAd.Text!="")
            {
                UrunGrup ug = new UrunGrup();
                ug.UrunGrupAd = tUrunGrupAd.Text;
                db.UrunGrup.Add(ug);
                db.SaveChanges();
                GrupDoldur();
                tUrunGrupAd.Clear();
                MessageBox.Show("Urun grubu eklenmistir");
                fUrunGiris f = (fUrunGiris)Application.OpenForms["fUrunGiris"];
                if(f!=null)
                {
                    f.GrupDoldur();
                }

            }
            else
            {
                MessageBox.Show("Grup Bilgisi Ekleyiniz");
            }
        }
        private void GrupDoldur()
        {
            listUrunGrup.DisplayMember = "UrunGrupAd";
            listUrunGrup.ValueMember = "Id";
            listUrunGrup.DataSource = db.UrunGrup.OrderBy(a => a.UrunGrupAd).toList();

        }

        private void bSil_Click(object sender, EventArgs e)
        {
            int grupid = Convert.ToInt32(listUrunGrup.SelectedValue.ToString());
            string grupad = listUrunGrup.Text;
            DialogResult dr = MessageBox.Show(grupad + " grubunu silmek istediginize emin misiniz ","Silme Islemi",MessageBoxButtons.YesNo);
            if(dr==DialogResult.Yes)
            {
                var grup = db.UrunGrup.FirstOrDefault(x => x.Id == grupid);
                db.UrunGrup.Remove(grup);
                db.SaveChanges();
                GrupDoldur();
                tUrunGrupAd.Focus();
                MessageBox.Show(grupad + "urun grubu silindi");
                fUrunGiris f = (fUrunGiris)Application.OpenForms["fUrunGiris"];
                f.GrupDoldur();
            }

        }
    }
}
