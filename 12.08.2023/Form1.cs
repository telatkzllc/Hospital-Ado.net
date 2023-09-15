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

namespace _12._08._2023
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("server =.;Database=hastane;Integrated Security=true;");




        private void Form1_Load(object sender, EventArgs e)
        {
            //projemiz hastane otomasyonu olacak.
            //hastalar tablosu olaacak hastano,adsoyad,yas,boy,kilo vb.
            //doktorlar tablosu olacak
            //poliklinik tablosu olacak.
            //recete tablosu lacak, tablonun alanları ve ilişki yapısı bizde.
            //sqlden başlanır.
            //kullanıcılar tablomuz olsun giris yapabilsin yeni kullanıcı ekleyebilsin ve silebilsin
            //yöneticiler kullanıcı girişi
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "yoneticigiris";
            cmd.Parameters.AddWithValue("@yoneticiad", textBox1.Text);
            cmd.Parameters.AddWithValue("@yoneticino", textBox2.Text);
            conn.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Giriş Yapılıyor Lütfen Bekleyiniz");
                page2 go = new page2();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız Tekrar Deneyiniz");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "userrgiris";
            cmd.Parameters.AddWithValue("@userrname", textBox4.Text);
            cmd.Parameters.AddWithValue("@userrno", textBox3.Text);
            conn.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Giriş Yapılıyor Lütfen Bekleyiniz");
                page2 go = new page2();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız Tekrar Deneyiniz");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (groupBox1.Visible = true)
            {
                groupBox2.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (groupBox2.Visible = true)
            {
                groupBox1.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            register go = new register();
            go.Show();
            this.Hide();
        }
    }
}
