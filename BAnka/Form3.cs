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

namespace BAnka
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Banka;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("insert into TBLKISILER (AD, SOYAD, TC, TELEFON, HESAPNO, SIFRE) values (@p1, @p2,@p3,@p4,@p5,@p6)",conn);
            sqlCommand.Parameters.AddWithValue("@p1",txtAd.Text);
            sqlCommand.Parameters.AddWithValue("@p2",txtSoyad.Text);
            sqlCommand.Parameters.AddWithValue("@p3",mskTC.Text);
            sqlCommand.Parameters.AddWithValue("@p4",mskTel.Text);
            sqlCommand.Parameters.AddWithValue("@p5",mskHesap.Text);
            sqlCommand.Parameters.AddWithValue("@p6",txtSifre.Text);
            sqlCommand.ExecuteNonQuery();
            
            conn.Close();
            MessageBox.Show("Kayıt Eklendi");
            Temizle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random ras= new Random();
            int sayi = ras.Next(100000, 1000000);
            mskHesap.Text = sayi.ToString();
        }

        void Temizle()
        {
            txtAd.Text = "";
            txtSifre.Text = "";
            txtSoyad.Text = "";
            mskHesap.Text = "";
            mskTC.Text = "";
            mskTel.Text ="";
        }
    }
}
