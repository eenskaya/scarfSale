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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\esarpsatis\esarpsatis.mdf; Integrated Security = true;");
        
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

            this.MaximumSize = new System.Drawing.Size(600, 535);
            this.MinimumSize = new System.Drawing.Size(600, 535);

            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Satis", baglanti);
            DataSet dataset = new DataSet();
            baglanti.Open();
            sgldataadapter.Fill(dataset, "Satis");
            dataGridView1.DataSource = dataset.Tables["Satis"];


    


            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(textBox5.Text);
            int price = Convert.ToInt32(ürünFiyat.Text);
            int total = 0;
            total = count * price;
            label8.Text = total.ToString() + " TL";
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            int adet;
            adet = int.Parse(textBox5.Text);
            baglanti.Open();
            DateTime now = DateTime.Today;
            var deger = now.ToString("dd.MM.yyyy");
            SqlCommand cmd = new SqlCommand("INSERT INTO Satis (müsteri_adı,müsteri_soyadı,müsteri_telefon,ürün_adı,ürün_adet,ürün_renk,ürün_fiyat,islem_tarih) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" +  textBox5.Text + "','" + ürünRenk.Text + "','"+ürünFiyat.Text+"','"+ deger.ToString() + "')", baglanti);
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("UPDATE Urün SET ürün_sayısı=ürün_sayısı-('" + adet + "') where ürü_adı='" + textBox4.Text + "'", baglanti);
            cmd2.ExecuteNonQuery();

            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Satis", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "Satis");
            dataGridView1.DataSource = dataset.Tables["Satis"];

            MessageBox.Show("Satış işlemi başarılı şekilde gerçekleşti !");
            this.Hide();
            baglanti.Close();
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string müsteri_adı = "";
            string müsteri_soyadı = "";
            string müsteri_telefon = "";

            string arama = textBox6.Text;
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM Müsteri  where müsteri_adı like '%" + arama.ToString() + "%'", baglanti);
            baglanti.Open();

            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                müsteri_adı = dr[1].ToString();
                müsteri_soyadı = dr[2].ToString();
                müsteri_telefon = dr[4].ToString();
            }
            textBox1.Text = müsteri_adı;
            textBox2.Text = müsteri_soyadı;
            textBox3.Text = müsteri_telefon;
            baglanti.Close();
        }
    }  
}
