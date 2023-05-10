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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Banka;Integrated Security=True");
        public string Hesap;
        private void Form2_Load(object sender, EventArgs e)
        {
            label6.Text = Hesap;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select AD, SOYAD, TC, TELEFON from TBLKISILER Where HESAPNO="+Hesap, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblAd.Text = dr[0] + " " + dr[1];
               lblTc.Text = dr[2].ToString();
                lblTel.Text = dr[3].ToString();

            }

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Alıcı hesabın para artmsı
            conn.Open();
            SqlCommand komut = new SqlCommand("update TBLHESAP set BAKIYE =BAKIYE+@p1 where HESAPNO=@p2", conn);
            komut.Parameters.AddWithValue("@p1", decimal.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            komut.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("bakiye aktarıldı");

            // Gönderen hesaptan para düşmesi
            conn.Open();
            SqlCommand komut1 = new SqlCommand("update TBLHESAP set BAKIYE =BAKIYE-@p1 where HESAPNO=" + Hesap, conn);
            komut1.Parameters.AddWithValue("@p1", decimal.Parse(textBox1.Text));
            komut1.ExecuteNonQuery();
            conn.Close();


            //Hareket Tablosu
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLHAREKET (ALICI, GONDEREN, TUTAR) values (@p1, @p2, @p3)", conn);
            cmd.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p2", Hesap);
            cmd.Parameters.AddWithValue("@p3", textBox1.Text);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 fr= new Form4();
            fr.Show();
        }
    }
}
