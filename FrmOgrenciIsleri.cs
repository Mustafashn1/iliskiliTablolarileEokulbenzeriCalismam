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
    public partial class FrmOgrenciIsleri : Form
    {
        public FrmOgrenciIsleri()
        {
            InitializeComponent();
        }



        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgretmen fr = new FrmOgretmen();
            fr.Show();
            this.Hide();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Eokulproje;Integrated Security=True");

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();



        private void FrmOgrenciIsleri_Load(object sender, EventArgs e)
        {

            //ÖNEMLİ 

            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_kulup", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbKulup.DisplayMember = "KULUPAD";
            CmbKulup.ValueMember = "KULUPID";
            CmbKulup.DataSource = dt;
            baglanti.Close();

        }
        string c = " ";

        private void BtnEkle_Click(object sender, EventArgs e)
        {


            ds.OGRENCIEKLE(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Başarılı Bir Şekilde Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();

        }

        private void CmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtId.Text = CmbKulup.SelectedValue.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            string v = TxtId.Text;


            try
            {
                baglanti.Open();


                SqlCommand komutNotlar = new SqlCommand("DELETE FROM Tbl_Notlar WHERE OGRID = @p1", baglanti);
                komutNotlar.Parameters.AddWithValue("@p1", v);
                komutNotlar.ExecuteNonQuery();


                SqlCommand komutOgrenciler = new SqlCommand("DELETE FROM Tbl_Ogrenciler WHERE OGRID = @p1", baglanti);
                komutOgrenciler.Parameters.AddWithValue("@p1", v);
                komutOgrenciler.ExecuteNonQuery();

                MessageBox.Show("Öğrenci Silme İşlemi Gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();


            string cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();


            if (cinsiyet == "Kadin")
            {
                radioButton1.Checked = true;

            }
            else if (cinsiyet == "Erkek")
            {

                radioButton2.Checked = true;
            }


        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            //ds.OgrGuncelleme(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), c, int.Parse(TxtId.Text));

            ds.OgrGuncelleme(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), c, int.Parse(TxtId.Text));
            MessageBox.Show("Güncelleme işlemi Gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }






        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "Kadın";
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OGRGETİR(TxtAra.Text);
        }
    }
}
