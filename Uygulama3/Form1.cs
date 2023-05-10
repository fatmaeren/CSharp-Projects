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

namespace Uygulama3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Rehber;Integrated Security=True");
        void RehberList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From KISILER", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            RehberList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Insert into KISILER (AD, SOYAD, TELEFON, MAIL) values (@p1,@p2,@p3,@p4)", conn);
            cmd.Parameters.AddWithValue("@p1", textBox2.Text);
            cmd.Parameters.AddWithValue("@p2", textBox3.Text);
            cmd.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p4", textBox4.Text);
            cmd.ExecuteNonQuery();           
            conn.Close();
            MessageBox.Show("Kişi Eklendi");
            RehberList();
            Temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete from KISILER where ID=" + textBox1.Text, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Kişi Silindi");
            RehberList();
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            textBox1.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            maskedTextBox1.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE KISILER SET AD=@P1, SOYAD=@P2, TELEFON=@P3, MAIL=@P4 WHERE ID=@P5", conn);
            cmd.Parameters.AddWithValue("@P1", textBox2.Text);
            cmd.Parameters.AddWithValue("@P2", textBox3.Text);
            cmd.Parameters.AddWithValue("@P4", textBox4.Text);
            cmd.Parameters.AddWithValue("@P3", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@P5", textBox1.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Kişi Güncellendi");
            RehberList();
            Temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        void Temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Text = "";
        }
    }
}
