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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=EtütTest;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            Kontrol();
            if (durum == true) { 
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("insert into TBLDERSLER (BransAd) values (@p1)",conn);
            sqlCommand.Parameters.AddWithValue("@p1", textBox1.Text);
            sqlCommand.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Ders Eklendi");
            this.Close();
            }
            else
            {
                MessageBox.Show("Ders zaten Ekli");
            }


        }

        bool durum;
        void Kontrol()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from TBLDERSLER where BransAd=@p1",conn);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text); 
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            conn.Close();
        }
    }
}
