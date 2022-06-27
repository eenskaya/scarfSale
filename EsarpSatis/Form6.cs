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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\esarpsatis\esarpsatis.mdf; Integrated Security = true;");

        private void Form6_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new System.Drawing.Size(600, 490);
            this.MinimumSize = new System.Drawing.Size(600, 490);


            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Satis", baglanti);
            DataSet dataset = new DataSet();
            baglanti.Open();
            sgldataadapter.Fill(dataset, "Satis");
            dataGridView1.DataSource = dataset.Tables["Satis"];
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Satis ORDER BY ürün_adet DESC", baglanti);
            DataSet dataset = new DataSet();
            baglanti.Open();

            sgldataadapter.Fill(dataset, "Satis");
            dataGridView1.DataSource = dataset.Tables["Satis"];

            baglanti.Close();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Satis ORDER BY ürün_adet ASC", baglanti);
            DataSet dataset = new DataSet();
            baglanti.Open();
            sgldataadapter.Fill(dataset, "Satis");
            dataGridView1.DataSource = dataset.Tables["Satis"];
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sql = "DELETE FROM Satis ";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kayıt Silindi...");

            SqlDataAdapter da = new SqlDataAdapter("Select * From Satis", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds, "Satis");
            dataGridView1.DataSource = ds.Tables["Satis"];

        }
    }
}
