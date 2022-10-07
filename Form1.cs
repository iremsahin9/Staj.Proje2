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

namespace Staj.Proje2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;
        SqlCommand komut;


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 3000;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            String harf = "ABCDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
            string uret = ("");
            for (int i = 0; i <= 5; i++)
            {
                uret += harf[rastgele.Next(harf.Length)];
                textBox1.Text = uret;
            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.ResetText();
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                String sorgu = "Insert into kelime(kelime) values (@kelime)";
                baglanti = new SqlConnection("Data Source=IREM;Initial Catalog=Staj; Integrated Security=True;");

                foreach (String items in listBox1.Items)
                {
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@kelime", items);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                }

                MessageBox.Show("Kayıt Başarı ile eklendi", "Kaydetme İşlemi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Kayıt Başarısız", "Kaydetme İşlemi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            }
        }
    }
}
