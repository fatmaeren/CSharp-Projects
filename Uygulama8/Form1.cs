using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Uygulama8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Rehber;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            //Şifreliyor
            string Ad = txtAd.Text;
            byte[] verisizi= ASCIIEncoding.ASCII.GetBytes(Ad);
            string sifreliveri= Convert.ToBase64String(verisizi);

            string Soyad = txtSoyad.Text;
            byte[] verisizi1 = ASCIIEncoding.ASCII.GetBytes(Soyad);
            string sifreliveri1 = Convert.ToBase64String(verisizi1);

            string Mail = txtMail.Text;
            byte[] verisizi2 = ASCIIEncoding.ASCII.GetBytes(Mail);
            string sifreliveri2 = Convert.ToBase64String(verisizi2);

            string Sifre = txtSifre.Text;
            byte[] verisizi3 = ASCIIEncoding.ASCII.GetBytes(Sifre);
            string sifreliveri3 = Convert.ToBase64String(verisizi3);

            string HesapNo = txtHesap.Text;
            byte[] verisizi4 = ASCIIEncoding.ASCII.GetBytes(HesapNo);
            string sifreliveri4 = Convert.ToBase64String(verisizi4);

            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLVERILER (AD,SOYAD, MAIL, SIFRE, HESAPNO) values (@p1,@p2,@p3,@p4,@p5)", conn);
            cmd.Parameters.AddWithValue("@p1", sifreliveri);
            cmd.Parameters.AddWithValue("@p2", sifreliveri1);
            cmd.Parameters.AddWithValue("@p3", sifreliveri2);
            cmd.Parameters.AddWithValue("@p4", sifreliveri3);
            cmd.Parameters.AddWithValue("@p5", sifreliveri4);
            cmd.ExecuteNonQuery();
            conn.Close();
         Listele();
        }

        void Listele()
        {
            SqlDataAdapter cmd = new SqlDataAdapter("Select * from TBLVERILER", conn);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Şifreleri Çözüyor
            string Ad = txtAd.Text;
            byte[] verisizi = Convert.FromBase64String(Ad);
            string sifreliveri = ASCIIEncoding.ASCII.GetString(verisizi);
            label6.Text = sifreliveri;
        }
    }
}
