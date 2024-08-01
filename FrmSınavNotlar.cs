using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace İlişkili_Tablolar_ile_E_Okul_Benzeri_Proje
{
    public partial class FrmSınavNotlar : Form
    {
        public FrmSınavNotlar()
        {
            InitializeComponent();
        }


        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Eokulproje;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(TxtOgrıd.Text));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgretmen fr = new FrmOgretmen();
            fr.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmSınavNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Ders", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbDers.DisplayMember = "DERSAD";
            CmbDers.ValueMember = "DERSID";
            CmbDers.DataSource = dt;
            baglanti.Close();
        }
        int notid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            TxtOgrıd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        int sınav1, sınav2, sınav3, proje;
        double ortalama;
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            
            // string durum;

            sınav1 = Convert.ToInt16(TxtSınav1.Text);
            sınav2 = Convert.ToInt16(TxtSınav2.Text);
            sınav3 = Convert.ToInt16(TxtSınav3.Text);
            proje = Convert.ToInt16(TxtProje.Text);
            ortalama = (sınav1 + sınav2 + sınav3 + proje) / 4;
            TxtOrtalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                TxtDurum.Text = " True ";
            }
            else
            {
                TxtDurum.Text = " False";
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
          
            ds.NotGuncelle(byte.Parse(CmbDers.SelectedValue.ToString()), int.Parse(TxtOgrıd.Text),byte.Parse(TxtSınav1.Text),byte.Parse(TxtSınav2.Text),byte.Parse(TxtSınav3.Text),byte.Parse(TxtProje.Text),decimal.Parse(TxtOrtalama.Text), bool.Parse(TxtDurum.Text), notid);
            MessageBox.Show("Güncelleme İşlemi Gerçekleşti.","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
