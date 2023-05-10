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

namespace OgrenciEtut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLETUT (DersId, OgretmenId,Tarih, Saat) values (@p1,@p2,@p3,@p4)",conn);
            cmd.Parameters.AddWithValue("@p1", cmbDers.SelectedValue);
            cmd.Parameters.AddWithValue("@p2", cmbDers.SelectedValue);
            cmd.Parameters.AddWithValue("@p3", mskTarih.Text);
            cmd.Parameters.AddWithValue("@p4", mskSaat.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Etüt başarı ile eklendi");

        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=EtütTest;Integrated Security=True");

        public void DersListesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLDERSLER",conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbDers.ValueMember = "Id";
            cmbDers.DisplayMember = "BransAd";
            cmbDers.DataSource = dt;
            EtütListesi();

        }

        //void OgretmenListesi()
        //{
        //    SqlDataAdapter da1 = new SqlDataAdapter("Select * From TBLOGRETMEN", conn);
        //    DataTable dt1 = new DataTable();
        //    da1.Fill(dt1);
        //    cmbOgr.ValueMember = "Id";
        //    cmbOgr.DisplayMember = "Ad" ;
        //    cmbOgr.DataSource = dt1;
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            DersListesi();
           EtütListesi();
            OgrenciList();
        }

        private void cmbDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from TBLOGRETMEN where BransId=" + cmbDers.SelectedValue, conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            cmbOgr.ValueMember = "Id";
            cmbOgr.DisplayMember = "Ad" ;
            cmbOgr.DataSource = dt1;
        }

        void EtütListesi()
        {
            SqlDataAdapter sqa = new SqlDataAdapter("Select TBLETUT.Id,(TBLOGRETMEN.Ad +' ' + TBLOGRETMEN.Soyad)  as Öğretmen,TBLDERSLER.BransAd as Ders, Tarih, Saat  from TBLETUT, TBLOGRETMEN, TBLDERSLER where TBLDERSLER.Id= TBLETUT.DersId and TBLOGRETMEN.Id=TBLETUT.OgretmenId ", conn);
            DataTable dt1 = new DataTable();
            sqa.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

       void OgrenciList()
        {
            SqlDataAdapter da3 = new SqlDataAdapter("select * from TBLOGRENCILER",conn);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            cmbOgrenci.ValueMember = "Id";
            cmbOgrenci.DisplayMember = "Ad";
            cmbOgrenci.DataSource = dt3;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnEtut_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update TBLETUT set ogrenciId=@p1 where Id=" + textBox1.Text, conn);
            cmd.Parameters.AddWithValue("@p1", cmbOgrenci.SelectedValue.ToString());
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Etüt Öğrenciye verildi");

        }

        private void btnDers_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void btnOgretmen_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.ShowDialog();
        }

        private void btnOgrenci_Click(object sender, EventArgs e)
        {
            Form4 form= new Form4();    
            form.ShowDialog();
        }
    }
}
