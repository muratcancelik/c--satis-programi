﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace CosmoMillaCosmetics
{
    class Nesnelerim
    {
    }

    class LStandart: Label
    {
        public LStandart()
        {
            this.ForeColor = System.Drawing.Color.DarkCyan;
            this.Text = "lStandart";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "lStandart";
        }
    }
    class bStandart: Button
    {
        public bStandart()
        {
            this.BackColor = System.Drawing.Color.Red;
            this.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.White;
            this.Image = global::CosmoMillaCosmetics.Properties.Resources.kredikarti;
            this.Location = new System.Drawing.Point(110, 1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "bKartbtn";
            this.Size = new System.Drawing.Size(107, 122);
            this.TabIndex = 1;
            this.Text = "Kart\r\n(F2)\r\n";
            this.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.UseVisualStyleBackColor = false;
        }
    }

    class tStandart:TextBox
    {
        public tStandart()
        {
            this.Size = new System.Drawing.Size(250, 26);
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            
        }
    }
    
    class tNumeric:TextBox
    {
        public tNumeric()
        {
            this.Size = new System.Drawing.Size(115, 26);
            this.BackColor =System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Name = "tNumeric";
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Click += TNumeric_Click;
            this.KeyPress += TNumeric_KeyPress;
        }

        private void TNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar)==false&&e.KeyChar!=(char)08&&e.KeyChar!=(char)44)
            {
                e.Handled = true;
            }
        }

        private void TNumeric_Click(object sender, EventArgs e)
        {
            this.SelectAll();
            
        }
    }

    class gridOzel:DataGridView
    {
        public gridOzel()
        {
            this.AllowUserToAddRows = false;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(3);
            this.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle =this.DefaultCellStyle;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DefaultCellStyle = this.DefaultCellStyle;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnableHeadersVisualStyles = false;
            this.Location = new System.Drawing.Point(0, 105);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "gridSatisListesi";
            this.RowHeadersVisible = false;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Size = new System.Drawing.Size(555, 517);
        }
    }
}
