using System;
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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmKulup fr = new FrmKulup();   
            fr.Show();
            this.Hide();

        }

        private void BtnDers_Click(object sender, EventArgs e)
        {
            FrmDers frm = new FrmDers();
            frm.Show();
            this.Hide();
        }

        private void BtnOgrenci_Click(object sender, EventArgs e)
        {
            FrmOgrenciIsleri fr = new FrmOgrenciIsleri();
            fr.Show();
        }

        private void FrmOgretmen_Load(object sender, EventArgs e)
        {

        }

        private void BtnSınav_Click(object sender, EventArgs e)
        {
            FrmSınavNotlar fr= new FrmSınavNotlar();
            fr.Show();
            this.Hide();
        }
    }
}