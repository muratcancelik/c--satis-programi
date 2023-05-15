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
    public partial class fRapor : Form
    {
        public fRapor()
        {
            InitializeComponent();
        }

        private void bAra_Click(object sender, EventArgs e)
       {
            Cursor.Current = Cursors.WaitCursor;
            DateTime baslangic = DateTime.Parse(dtBaslangic.Value.ToShortDateString());
            DateTime bitis = DateTime.Parse(dtBitis.Value.ToShortDateString());
            bitis = bitis.AddDays(1);
            using(var db = new BarkodDbEntites())
            {
                if(listFiltreleme.SelectedIndex==0)
                {
                    db.IslemOzet.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis).OrderByDescending(x => x.Tarih).Load();
                    var islemozet = db.IslemOzet.Local.ToBindingList();
                    gridListe.DataSource = islemozet;

                    tSatisKart.Text = Convert.ToDouble(islemozet.Where(x => x.Iade = false && x.Gelir == false && x.Gider == false).Sum(x => x.Nakit).toString("C2"));
                    tSatisKart.Text = Convert.ToDouble(islemozet.Where(x => x.Iade == false && x.Gelir == false && x.Gider == false).Sum(x => x.Kart).ToString("C2"));

                    tIadeNakit.Text = Convert.ToDouble(islemozet.Where(x => x.Iade == true).Sum(x => x.Nakit)).ToString("C2");
                    tIadeKart.Text = Convert.ToDouble(islemozet.Where(x => x.Iade == true).Sum(x => x.Kart)).ToString("C2");


                    tGelirNakit.Text = Convert.ToDouble(islemozet.Where(x => x.Gelir == true).Sum(s => s.Nakit)).ToString("C2");
                    tGelirKart.Text = Convert.ToDouble(islemozet.Where(x => x.Gelir == true).Sum(s => s.Kart)).ToString("C2");

                    tGiderNakit.Text = Convert.ToDouble(islemozet.Where(x => x.Gider == true).Sum(s => s.Nakit)).ToString("C2");
                    tGiderKart.Text = Convert.ToDouble(islemozet.Where(x => x.Gider == true).Sum(s => s.Kart)).ToString("C2");

                    db.Satis.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis).Load();

                    var satistablosu = db.Satis.Local.ToBindingList();

                    double kdvtutarisatis = Islemler.DoubleYap(satistablosu.Where(x => x.Iade == false).Sum(x => x.KdvTutari).ToString());
                    double kdvtutariiade = Islemler.DoubleYap(satistablosu.Where(x => x.Iade == true).Sum(x => x.KdvTutari).ToString());
                    tKdvToplam.Text = (kdvtutarisatis - kdvtutariiade).ToString("C2");

                }
            }





            Cursor.Current = Cursors.Default;
        }

        private void bGelirEkle_Click(object sender, EventArgs e)
        {

        }

        private void fRapor_Load(object sender, EventArgs e)
        {
            listFiltreleme.SelectedIndex = 0;
            tKartKomisyon.Text = Islemler.KartKomisyon().ToString();
        }
    }
}
