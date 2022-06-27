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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\esarpsatis\esarpsatis.mdf; Integrated Security = true;");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            int adet = Convert.ToInt32(textBox1.Text);
            SqlCommand cmd2 = new SqlCommand("UPDATE Urün SET ürün_sayısı=ürün_sayısı+('" + adet + "') where ürü_adı='" + label2.Text + "'", baglanti);
            cmd2.ExecuteNonQuery();


            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Urün", baglanti);
            DataSet dataset = new DataSet();           
            sgldataadapter.Fill(dataset, "Urün");
            var myForm = new Form8();
            myForm.Show();
            myForm.dataGridView1.DataSource = dataset.Tables["Urün"];
            baglanti.Close();
            this.Hide();
            MessageBox.Show("Stok eklendi !");

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new System.Drawing.Size(330, 215);
            this.MinimumSize = new System.Drawing.Size(330, 215);
        }
    }
}
