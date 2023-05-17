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
    public partial class fUrunGiris : Form
    {
        public fUrunGiris()
        {
            InitializeComponent();
        }

        BarkodDbEntities db = new BarkodDbEntities();
        private void tBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                string barkod = tBarkod.Text.Trim();
                if(db.Urun.Any(a=>a.Barkod==barkod))
                {
                    var urun = db.Urun.Where(a => a.Barkod == barkod).SingleOrDefault();
                    tUrunAdi.Text = urun.UrunAd;
                    tAciklama.Text = urun.Aciklama;
                    cmbUrunGrubu.Text = urun.UrunGrubu;
                    tAlisFiyati.Text = urun.AlisFiyati.toString();
                    tSatisFiyati.Text = urun.SatisFiyati.toString();
                    tMiktar.Text = urun.Miktar.toString();
                    tKdvOrani.Text = urun.KdvOrani.toString();
                    if(urun.Birim=="Kg")
                    {
                        chUrunTipi.Checked = true;
                    }
                    else
                    {
                        chUrunTipi.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("Urun kayitli degil, kaydedebilirsiniz.");
                }
            }
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {
            if(tBarkod.Text!=""&&tUrunAdi.Text!=""&&cmbUrunGrubu.Text!=""&&tAlisFiyati.Text!=""&&tSatisFiyati.Text!=""&&tKdvOrani.Text!=""&&tMiktar.Text!="")
            {
                if(db.Urun.Any(a=>a.Barkod==tBarkod.Text))
                {
                    var guncelle = db.Urun.Where(a => a.Barkod == tBarkod.Text).SingleOrDefault();
                    guncelle.Barkod = tBarkod.Text;
                    guncelle.UrunAd = tUrunAdi.Text;
                    guncelle.Aciklama = tAciklama.Text;
                    guncelle.UrunGrup = cmbUrunGrubu.Text;
                    guncelle.AlisFiyat = Convert.ToDouble(tAlisFiyati.Text);
                    guncelle.SatisFiyat = Convert.ToDouble(tSatisFiyati.Text);
                    guncelle.KdvOrani = Convert.ToInt16(tKdvOrani.Text);
                    guncelle.KdvTutari = Math.Round(Islemler.DoubleYap(tSatisFiyati.Text) * Convert.ToInt32(tKdvOrani.Text) / 100, 2);
                    guncelle.Miktar += Convert.ToDouble(tMiktar.Text);
                    if(chUrunTipi.Checked)
                    {
                        guncelle.Birim = "Kg";
                    }
                    else
                    {
                        guncelle.Birim = "Adet";
                    }
                    guncelle.Tarih = DateTime.Now;
                    guncelle.Kullanici = lKullanici.Text;
                    db.SaveChanges();
                    gridUrunler.DataSource = db.Urun.OrderbyDescending(a => a.UrunID).Take(10).toList();

                }
                else
                {
                    Urun urun = new Urun();
                    urun.Barkod = tBarkod.Text;
                    urun.UrunAd = tUrunAdi.Text;
                    urun.Aciklama = tAciklama.Text;
                    urun.UrunGrup = cmbUrunGrubu.Text;
                    urun.AlisFiyat = Convert.ToDouble(tAlisFiyati.Text);
                    urun.SatisFiyat = Convert.ToDouble(tSatisFiyati.Text);
                    urun.KdvOrani = Convert.ToInt16(tKdvOrani.Text);
                    urun.KdvTutari = Math.Round(Islemler.DoubleYap(tSatisFiyati.Text) * Convert.ToInt32(tKdvOrani.Text) / 100, 2);
                    urun.Miktar = Convert.ToDouble(tMiktar.Text);
                    if(chUrunTipi.Checked)
                    {
                        urun.Birim = "Kg";
                    }
                    else
                    {
                        urun.Birim = "Adet";
                    }
                    urun.Tarih = DateTime.Now;
                    urun.Kullanici = lKullanici.Text;
                    db.Urun.Add(urun);
                    db.SaveChanges();
                    if(tBarkod.Text.Length==8)
                    {
                        var ozelbarkod = db.Barkod.First();
                        ozelbarkod.BarkodNo += 1;
                        db.SaveChanges();
                    }
                    
                    gridUrunler.DataSource = db.Urun.OrderbyDescending(a => a.UrunID).Take(20).toList();
                    Islemler.GridDuzenle(gridUrunler);
                }
                Islemler.StokHareket(tBarkod.Text, tUrunAdi.Text, "Adet", Convert.ToDouble(tMiktar.Text), cmbUrunGrubu.Text, lKullanici2.Text);
                temizle();

            }
            else
            {
                MessageBox.Show("bilgi girislerini kontrol ediniz");
                tBarkod.Focus();
            }
        }

        private void tUrunAra_TextChanged(object sender, EventArgs e)
        {
            if(tUrunAra.Text.Length>=2)
            {
                string urunad = tUrunAra.Text;
                gridUrunler.DataSource = db.Urun.Where(a => a.UrunAd.Equals(urunad)).toList();
                Islemler.GridDuzenle(gridUrunler);
            }
        }
        private void temizle()
        {
            tBarkod.Clear();
            tUrunAdi.Clear();
            tAciklama.Clear();
            tAlisFiyati.Text = "0";
            tSatisFiyati.Text = "0";
            tMiktar.Text = "0";
            tKdvOrani.Text = "8";
            chUrunTipi.Checked = false;
        }

        private void fUrunGiris_Load(object sender, EventArgs e)
        {
            tUrunSayisi.Text = db.Urun.Count().ToString();
            gridUrunler.DataSource = db.Urun.OrderbyDescending(a => a.UrunID).Take(20).toList();
            Islemler.GridDuzenle(gridUrunler);
            GrupDoldur();
        }

        private void bUrunGrubuEkle_Click(object sender, EventArgs e)
        {
            fUrunGiris fUrun = new fUrunGiris();
            fUrun.ShowDialog();
        }
        public void GrupDoldur()
        {
            cmbUrunGrubu.DisplayMember = "UrunGrupAd";
            cmbUrunGrubu.ValueMember = "Id";
            cmbUrunGrubu.DataSource = db.UrunGrup.OrderBy(a => a.UrunGrupAd).toList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //barkod butonu
            var barkodno = db.Barkod.First();
            int karakter = barkodno.BarkodNo.toString().Length;
            string sifirlar = string.Empty;
            for(int i=0;i<8-karakter;i++)
            {
                sifirlar = sifirlar + "0";
            }
            string olusanbarkod = sifirlar + barkodno.BarkodNo.ToString();
            tBarkod.Text = olusanbarkod;
            tUrunAdi.Focus();
        }

        private void tSatisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar)==false&&e.KeyChar!=(char)08&&e.KeyChar!=(char)44&&e.KeyChar!=(char)45)
            {
                e.Handled = true;
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(gridUrunler.Rows.Count > 0)
            {
                int urunid = Convert.ToInt32(gridUrunler.CurrentRow.Cells["UrunId"].Value.ToString());
                string urunad = gridUrunler.CurrentRow.Cells["UrunAd"].Value.ToString();
                string barkod = gridUrunler.CurrentRow.Cells["Barkod"].Value.ToString();
                DialogResult onay = MessageBox.Show(urunad + "Ürününü silmek istiyor musunuz ?", "Ürün Silme İşlemi", MessageBoxButtons.YesNo);
                if(onay == DialogResult.Yes)
                {
                    var urun = db.Urun.Find(urunid);
                    db.Urun.Remove(urun);
                    db.SaveChanges();
                    var hizliurun=db.HizliUrun.Where(x=> x.Barkod == barkod).SingleOrDefault();
                    hizliurun.Barkod = "-";
                    hizliurun.UrunAd = "-";
                    hizliurun.Fiyat = 0;
                    db.SaveChanges(); 
                    MessageBox.Show("Ürün silinmiştir");
                    gridUrunler.DataSource = db.Urun.OrderbyDescending(a => a.UrunID).Take(20).toList();
                    Islemler.GridDuzenle(gridUrunler);
                    tBarkod.Focus();
                }
            }

        }

        private void chUrunTipi_CheckedChanged(object sender, EventArgs e)
        {
            if(chUrunTipi.Checked)
            {
                chUrunTipi.Text = "Gramajli Urun Islemi";
                bBarkodOlustur.Enabled = false;

            }
            else
            {
                chUrunTipi.Text = "Barkodlu Urun Islemi";
                bBarkodOlustur.Enabled = true;
            }
        }

        private void duzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(gridUrunler.Rows.Count>0)
            {
                tBarkod.Text = gridUrunler.CurrentRow.Cells["Barkod"].Value.ToString();
                tUrunAdi.Text = gridUrunler.CurrentRow.Cells["UrunAdi"].Value.ToString();
                tAciklama.Text = gridUrunler.CurrentRow.Cells["Aciklama"].Value.ToString();
                cmbUrunGrubu.Text = gridUrunler.CurrentRow.Cells["UrunGrup"].Value.ToString();
                tAlisFiyati.Text = gridUrunler.CurrentRow.Cells["AlisFiyat"].Value.ToString();
                tSatisFiyati.Text = gridUrunler.CurrentRow.Cells["SatisFiyat"].Value.ToString();
                tKdvOrani.Text = gridUrunler.CurrentRow.Cells["KdvOran"].Value.ToString();
                tMiktar.Text = gridUrunler.CurrentRow.Cells["Miktar"].Value.ToString();
                string birim = gridUrunler.CurrentRow.Cells["Birim"].Value.ToString();
                if(birim=="Kg")
                {
                    chUrunTipi.Checked = true;
                }
                else
                {
                    chUrunTipi.Checked = false;
                }

            }
        }
    }
   

}
