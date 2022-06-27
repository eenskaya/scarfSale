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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\esarpsatis\esarpsatis.mdf; Integrated Security = true;");


        private void button1_Click(object sender, EventArgs e)
        {
            var myForm = new Form4();
            myForm.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new System.Drawing.Size(680, 345);
            this.MinimumSize = new System.Drawing.Size(680, 345);

            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Urün", baglanti);
            DataSet dataset = new DataSet();
            baglanti.Open();
            sgldataadapter.Fill(dataset, "Urün");
            dataGridView1.DataSource = dataset.Tables["Urün"];
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var myForm = new Form3();
            myForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
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

            MessageBox.Show("Ürüm Başarılı Şekilde Silindi");

            baglanti.Close();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            var myForm = new Form7();
            myForm.Show();

            myForm.label7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            myForm.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            myForm.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            myForm.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            myForm.textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            myForm.textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var myForm = new Form5();
            myForm.Show();
            myForm.textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            myForm.ürünFiyat.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            myForm.textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString(); 
            myForm.ürünRenk.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {

            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Urün", baglanti);
            DataSet dataset = new DataSet();
            baglanti.Open();
            sgldataadapter.Fill(dataset, "Urün");
            dataGridView1.DataSource = dataset.Tables["Urün"];
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var myForm = new Form6();
            myForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var myForm = new Form8();
            myForm.Show();
        }
    }
}
