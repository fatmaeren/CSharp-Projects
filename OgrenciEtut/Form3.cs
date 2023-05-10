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

namespace OgrenciEtut
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            DersListesi();

        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=EtütTest;Integrated Security=True");

        void DersListesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLDERSLER", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "BransAd";
            comboBox1.DataSource = dt;
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("insert into TBLOGRETMEN (Ad, Soyad, BransId) values (@p1,@p2,@p3)",conn);
            sqlCommand.Parameters.AddWithValue("@p1", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@p2", textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@p3", comboBox1.SelectedValue);
            sqlCommand.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Öğretmen Başarı ile Eklendi");

            this.Close();
        }
    }
}
