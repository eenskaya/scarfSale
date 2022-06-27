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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }



        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\esarpsatis\esarpsatis.mdf; Integrated Security = true;");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into Müsteri (müsteri_adı,müsteri_soyadı,müsteri_tc,müsteri_telefon,müsteri_adres)   values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);
            cmd.ExecuteNonQuery();


            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Müsteri", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "Müsteri");
            dataGridView1.DataSource = dataset.Tables["Müsteri"];


            //TEXTBOXLARIN İÇERİSİNDEKİ DEGERLERİ SİLDİM.
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            MessageBox.Show("Ürün Başarılı Şekilde Eklendi !");

            baglanti.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            this.MaximumSize = new System.Drawing.Size(600, 490);
            this.MinimumSize = new System.Drawing.Size(600, 490);


            baglanti.Open();
            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Müsteri", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "Müsteri");
            dataGridView1.DataSource = dataset.Tables["Müsteri"];


            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            int id=0;

            //Seçili Satırları Silme
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  
            {
                 id = Convert.ToInt32(drow.Cells[0].Value);
            }

            //DATAGİRİTDEN SEÇİLEN SATIRI SİLME İŞLEMİ
            string sql = "DELETE FROM Müsteri WHERE id=@id";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@id", id);
            komut.ExecuteNonQuery();

            //MÜSTERİ TABLOSUNU TEKRAR DATAGRİD E YAZDIRIYORUM
            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Müsteri", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "Müsteri");
            dataGridView1.DataSource = dataset.Tables["Müsteri"];

            baglanti.Close();

            MessageBox.Show("Müşteri başarılı şeklide silindi !");

        }

        SqlDataAdapter da;
        SqlCommandBuilder cbuilder;
        SqlCommand komut;
        DataSet ds;

        private void button3_Click(object sender, EventArgs e)
        {
             baglanti.Open();


            try
            {
              
                da = new SqlDataAdapter("SELECT * FROM Urün", baglanti);
                cbuilder = new SqlCommandBuilder(da);
                da.Update(ds, "Urün");
           
                MessageBox.Show("Ürün Başarılı Şekilde Güncellendi");

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ürüm Güncellenemedi ! " + ex);
            }

            MessageBox.Show("Müsteri Başarılı Şekilde Güncellendi");
        }
    }
}
