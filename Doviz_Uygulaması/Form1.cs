using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Doviz_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya= new XmlDocument();
            xmldosya.Load(bugun);

            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            LblDolarAlis.Text = dolaralis;

            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            LblDolarSatis.Text = dolarsatis;

            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            LblEuroAlis.Text = euroalis;

            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            LblEuroSatis.Text = eurosatis;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text=LblDolarAlis.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = LblDolarSatis.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = LblEuroAlis.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = LblEuroSatis.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tutar = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox2.Text);
            textBox3.Text= Convert.ToInt32(tutar).ToString();
            double kalan;
            kalan = Convert.ToInt32(textBox2.Text) % Convert.ToDouble(textBox1.Text);
            textBox4.Text = kalan.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(".", ",");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            var tutar = Convert.ToInt32(textBox2.Text) / Convert.ToDouble(textBox1.Text);
            textBox3.Text = Convert.ToInt32(tutar).ToString();
            double kalan;
            kalan = Convert.ToInt32(textBox2.Text) % Convert.ToDouble(textBox1.Text);
            textBox4.Text= kalan.ToString();
        }
    }
}
