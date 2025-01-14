﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace İlişkili_Tablolar_ile_E_Okul_Benzeri_Proje
{
    public partial class FrmDers : Form
    {
        public FrmDers()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_DersTableAdapter ds = new DataSet1TableAdapters.Tbl_DersTableAdapter();

        private void FrmDers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgretmen frm = new FrmOgretmen();
            frm.Show();
            this.Hide();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(TxtDersAd.Text);
            MessageBox.Show("Ders Ekleme İşlemi Başarıyla Gerçekleşti","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(TxtDersid.Text)); 
            MessageBox.Show("Silme İşlemi Başarılı bir Şekilde Gerçekleşti","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);   
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(TxtDersAd.Text, byte.Parse(TxtDersid.Text));
            MessageBox.Show("Güncelleme İşlemi Başarılı bir Şekilde Gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtDersid.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDersAd.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
