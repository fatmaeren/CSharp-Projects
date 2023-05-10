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
    public partial class Form4 : Form
    {
        string hesap;
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Banka;Integrated Security=True");
        private void Form4_Load(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            hesap = form2.Hesap;
           
            SqlCommand sdar = new SqlCommand("Select * from TBLHAREKET",conn);         
            SqlDataAdapter da2= new SqlDataAdapter();
            da2.SelectCommand=sdar;
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }
    }
}
