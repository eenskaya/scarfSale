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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\esarpsatis\esarpsatis.mdf; Integrated Security = true;");

        private void Form7_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new System.Drawing.Size(610, 500);
            this.MinimumSize = new System.Drawing.Size(610, 500);

            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Urün", baglanti);
            DataSet dataset = new DataSet();
            baglanti.Open();
            sgldataadapter.Fill(dataset, "Urün");
            dataGridView1.DataSource = dataset.Tables["Urün"];
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            baglanti.Open();

         
            SqlCommand cmd = new SqlCommand("UPDATE Urün SET  ürü_adı='"+textBox1.Text+"', ürün_renk='" + textBox2.Text + "',ürün_markası='" + textBox3.Text + "',ürün_sayısı='" + textBox4.Text + "',ürün_fiyatı='" + textBox5.Text + "' where id='" + label7.Text + "'", baglanti);
            cmd.ExecuteNonQuery();

            //komut.CommandText = "UPDATE ogrenci SET ograd='" + ad + "',ogrsoyad='" + soyad + "',sinif='" + sinif + "' WHERE ogrno=" + no.ToString();


            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Urün", baglanti);
            DataSet dataset = new DataSet();
            sgldataadapter.Fill(dataset, "Urün");
            dataGridView1.DataSource = dataset.Tables["Urün"];

            this.Hide();


            baglanti.Close();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
