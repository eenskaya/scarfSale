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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\esarpsatis\esarpsatis.mdf; Integrated Security = true;");

        private void Form8_Load(object sender, EventArgs e)
        {

            this.MaximumSize = new System.Drawing.Size(730, 490);
            this.MinimumSize = new System.Drawing.Size(730, 490);

            SqlDataAdapter sgldataadapter = new SqlDataAdapter("Select * From Urün ORDER BY ürün_sayısı ASC", baglanti);
            DataSet dataset = new DataSet();
            baglanti.Open();
            sgldataadapter.Fill(dataset, "Satis");
            dataGridView1.DataSource = dataset.Tables["Satis"];
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            string kayit = "SELECT * FROM Urün  where ürü_adı like '%"+textBox1.Text+"%'";
            SqlDataAdapter adap = new SqlDataAdapter(kayit, baglanti);
            DataSet dqwes = new DataSet();
            adap.Fill(dqwes, "Urün");
            dataGridView1.DataSource = dqwes.Tables[0];
            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var myForm = new Form9();
            myForm.Show();
            this.Hide();
            myForm.label2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
