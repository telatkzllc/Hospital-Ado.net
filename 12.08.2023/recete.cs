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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _12._08._2023
{
    public partial class recete : Form
    {
        public recete()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("server =.;Database=hastane;Integrated Security=true;");
        public void listele()
        {

            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "recetelistele";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable fillData = new DataTable();
            dr.Fill(fillData);
            dataGridView1.DataSource = fillData;
        }
        public void temizleme()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();


        }
        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "receteekle";
            DateTime Tarih = Convert.ToDateTime(dateTimePicker1.Text);
            command.Parameters.AddWithValue("recetetanım", textBox1.Text);
            command.Parameters.AddWithValue("recetetarih", Tarih);
            command.Parameters.AddWithValue("hastano", textBox2.Text);
            command.Parameters.AddWithValue("doktorno", textBox3.Text);
            command.ExecuteNonQuery();
            listele();
            temizleme();
            conn.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["receteno"].Value.ToString();
            textBox1.Text = satir.Cells["recetetanım"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["recetetarih"].Value.ToString();
            textBox2.Text = satir.Cells["hastano"].Value.ToString();
            textBox3.Text = satir.Cells["doktorno"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "receteupdate";
            DateTime Tarih = Convert.ToDateTime(dateTimePicker1.Text);
            command.Parameters.AddWithValue("receteno", textBox1.Tag);
            command.Parameters.AddWithValue("recetetanım", textBox1.Text);
            command.Parameters.AddWithValue("recetetarih", Tarih);
            command.Parameters.AddWithValue("hastano", textBox2.Text);
            command.Parameters.AddWithValue("doktorno", textBox3.Text);
            command.ExecuteNonQuery();
            MessageBox.Show(" güncelleme İşlemi Başarılı");
            listele();
            temizleme();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "recetesil";
            command.Parameters.AddWithValue("@receteno", textBox1.Tag);
            command.ExecuteNonQuery();
            MessageBox.Show(" Silme İşlemi Başarılı");
            listele();
            temizleme();
            conn.Close();
        }

        private void recete_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["receteno"].Value.ToString();
            textBox1.Text = satir.Cells["recetetanım"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["recetetarih"].Value.ToString();
            textBox2.Text = satir.Cells["hastano"].Value.ToString();
            textBox3.Text = satir.Cells["doktorno"].Value.ToString();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "sonbesrecete";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable fillData = new DataTable();
            dr.Fill(fillData);
            dataGridView1.DataSource = fillData;
        }
    }
}
