﻿using System;
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

        public void bEkle_Click(object sender, EventArgs e)
        {
            if(cmbOdemeTuru.Text!="")
            {
                if(tNakit.Text!=""&&tKart.Text!="")
                {
                    using(var db=new BarkodDbEntities())
                    {
                        IslemOzet io = new IslemOzet();
                        io.IslemNo = 0;
                        io.Iade = false;
                        io.OdemeSekli = cmbOdemeTuru.Text;
                        io.Nakit = Islemler.DoubleYap(tNakit.Text);
                        io.Kart = Islemler.DoubleYap(tKart.Text);
                        if(gelirgider=="GELIR")
                        {
                            io.Gider = false;
                            io.Gelir = true;
                        }
                        else
                        {
                            io.Gelir = false;
                            io.Gider = true;
                        }
                        io.AlisFiyatToplam = 0;
                        io.Aciklama = gelirgider + " -  Islemi " + tAciklama.Text;
                        io.Tarih = dtTarih.Value;
                        io.Kullanici = kullanici;
                        db.IslemOzet.Add(io);
                        db.IslemOzet.SaveChanges();
                        MessageBox.Show(gelirgider + " islemi kaydedildi");
                        tNakit.Text = "0";
                        tKart.Text = "0";
                        tAciklama.Clear();
                        cmbOdemeTuru.Text = "";
                        fRapor rapor = (fRapor)Application.OpenForms["fRapor"];
                        if(rapor!=null)
                        {
                            rapor.bGoster_Click(null, null);
                        }
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lutfen odeme turunu belirleyiniz");
            }
        }
    }
}
