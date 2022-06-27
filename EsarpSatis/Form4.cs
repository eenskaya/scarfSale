using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsarpSatis
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\esarpsatis\esarpsatis.mdf; Integrated Security = true;");


        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into Urün (ürü_adı,ürün_renk,ürün_markası,ürün_sayısı,ürün_fiyatı)   values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);
            cmd.ExecuteNonQuery();


            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Urün", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "Urün");
            dataGridView1.DataSource = dataset.Tables["Urün"];


            //TEXTBOXLARIN İÇERİSİNDEKİ DEGERLERİ SİLDİM.
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            MessageBox.Show("Ürün Başarılı Şekilde Eklendi !");
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            int id = 0;

            //Seçili Satırları Silme
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                id = Convert.ToInt32(drow.Cells[0].Value);
            }

            //DATAGİRİTDEN SEÇİLEN SATIRI SİLME İŞLEMİ
            string sql = "DELETE FROM Urün WHERE id=@id";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@id", id);
            komut.ExecuteNonQuery();

            //MÜSTERİ TABLOSUNU TEKRAR DATAGRİD E YAZDIRIYORUM
            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Urün", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "Urün");
            dataGridView1.DataSource = dataset.Tables["Urün"];

            baglanti.Close();

            MessageBox.Show("Ürün başarılı şekilde silindi !");
        }


        SqlDataAdapter da;
        SqlCommandBuilder cbuilder;
        DataSet ds;
        SqlCommand komut;

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                da = new SqlDataAdapter("SELECT * FROM Urün", baglanti);
                cbuilder = new SqlCommandBuilder(da);
                da.Update(ds, "Urün");

                baglanti.Close();
                MessageBox.Show("Ürüm Başarılı Şekilde Güncellendi");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ürüm Güncellenemedi ! " + ex);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            this.MaximumSize = new System.Drawing.Size(610, 465);
            this.MinimumSize = new System.Drawing.Size(610, 465);


            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Urün", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "Urün");
            dataGridView1.DataSource = dataset.Tables["Urün"];

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
