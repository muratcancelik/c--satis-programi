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
    public partial class fStok : Form
    {
        public fStok()
        {
            InitializeComponent();
        }

        private void bAra_Click(object sender, EventArgs e)
        {
            gridListe.DataSource = null;
            using(var db=new BarkodDbEntities())
            {
                string urungrubu = cmbUrunGrubu.Text;
                if(cmbIslemTuru.Text!="")
                {
                    if(cmbIslemTuru.SelectedIndex==0)
                    {
                        if(rdTumu.Checked)
                        {
                            db.Urun.OrderBy(x => x.Miktar).Load();
                            gridListe.DataSource = db.Urun.Local.ToBindingList();
                        }
                        else if(rdUrunGrubunaGore.Checked)
                        {
                            db.Urun.Where(x => x.UrunGrup == urungrubu).OrderBy(x => x.Miktar).Load();
                            gridListe.DataSource = db.Urun.Local.ToBindingList();
                        }
                        else
                        {
                            MessageBox.Show("Lutfen Filtreleme Turunu Seciniz");
                        }

                    }
                    else if (cmbIslemTuru.SelectedIndex==1)
                    {
                        DateTime baslangic = DateTime.Parse(dateBaslangic.Value.ToShortDateString());
                        DateTime bitis = DateTime.Parse(dateBitis.Value.ToShortDateString());
                        bitis = bitis.AddDays(1);
                        if(rdTumu.Checked)
                        {
                            db.StokHareket.OrderByDescending(x => x.Tarih).Where(x => x.Tarih >= baslangic && x.Tarih <= bitis).Load();
                            gridListe.DataSource = db.StokHareket.Local.ToBindingList();
                        }
                        else if(rdUrunGrubunaGore.Checked)
                        {
                            db.StokHareket.OrderByDescending(x => x.Tarih).Where(x => x.Tarih >= baslangic && x.Tarih <= bitis && x.UrunGrup.Contains(urungrubu)).Load();
                            gridListe.DataSource = db.StokHareket.Local.ToBindingList();
                        }
                        else
                        {
                            MessageBox.Show("Lutfen Filtreleme Turunu Seciniz ");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lutfen Islem Turunu Seciniz ");
                }
            }
            Islemler.GridDuzenle(gridListe);
        }

        BarkodDbEntities dbx = new BarkodDbEntities();  
        private void fStok_Load(object sender, EventArgs e)
        {
            cmbUrunGrubu.DisplayMember = "UrunGrupAd";
            cmbUrunGrubu.ValueMember = "ID";
            cmbUrunGrubu.DataSource = dbx.UrunGrup.toList();
        }

        private void tUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (tUrunAra.Text.Length>=3)
            {
                string urunad = tUrunAra.Text;
                using(var db=new BarkodDbEntities())
                {
                    if(cmbIslemTuru.SelectedIndex==0)
                    {
                        db.Urun.Where(x => x.UrunAd.Contains(urunad)).Load();
                        gridListe.DataSource = db.Urun.Local.ToBindingList();
                    }
                    else if(cmbIslemTuru.SelectedIndex==1)
                    {
                        db.StokHareket.Where(x => x.UrunAd.Contains(urunad).Load());
                        gridListe.DataSource = db.Urun.Local.ToBindingList(); 
                    }
                }
                Islemler.GridDuzenle(gridListe);
            }
        }
    }
}
