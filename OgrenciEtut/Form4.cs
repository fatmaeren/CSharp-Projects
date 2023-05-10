using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace OgrenciEtut
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=EtütTest;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation=openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLOGRENCILER (Ad, Soyad, Sınıf, Fotograf, Telefon, Mail ) values (@p1, @p2, @p3,@p4,@p5,@p6)",conn);
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", txtSınıf.Text);
            cmd.Parameters.AddWithValue("@p4", pictureBox1.ImageLocation);
            cmd.Parameters.AddWithValue("@p5", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p6", txtMail.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Öğrenci Kayıt Edildi");
            this.Close();
        }
    }
}
