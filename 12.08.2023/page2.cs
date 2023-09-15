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
    public partial class page2 : Form
    {
        public page2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("server =.;Database=hastane;Integrated Security=true;");
        private string yasort;

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void listele()
        {

            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "hastalistele";
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
                textBox4.Clear();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void page2_Load(object sender, EventArgs e)
        {
            //Sqlde comboboxa çekmek
            SqlCommand kmt=new SqlCommand("SELECT * FROM hastalar",conn);

            SqlDataReader dr;
            conn.Open();
            dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["hastano"]);
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "hastaekle";
            command.Parameters.AddWithValue("adsoyad", textBox1.Text);
            command.Parameters.AddWithValue("yas", textBox2.Text);
            command.Parameters.AddWithValue("boy", textBox3.Text);
            command.Parameters.AddWithValue("kilo", textBox4.Text);
            command.ExecuteNonQuery();

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
            command.CommandText = "hastasil";
            command.Parameters.AddWithValue("@hastano", textBox1.Tag);
            command.ExecuteNonQuery();
            MessageBox.Show(" Silme İşlemi Başarılı");
            listele();
            temizleme();
            conn.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["hastano"].Value.ToString();
            textBox1.Text = satir.Cells["adsoyad"].Value.ToString();
            textBox2.Text = satir.Cells["yas"].Value.ToString();
            textBox3.Text = satir.Cells["boy"].Value.ToString();
            textBox4.Text = satir.Cells["kilo"].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "hastaupdate";
            command.Parameters.AddWithValue("hastano", textBox1.Tag);
            command.Parameters.AddWithValue("adsoyad", textBox1.Text);
            command.Parameters.AddWithValue("yas", textBox2.Text);
            command.Parameters.AddWithValue("boy", textBox3.Text);
            command.Parameters.AddWithValue("kilo", textBox4.Text);
            command.ExecuteNonQuery();
            MessageBox.Show(" güncelleme İşlemi Başarılı");
            listele();
            temizleme();
            conn.Close();

        }

        private void recetelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recete go = new recete();
            go.Show();
            this.Hide();
        }

        private void hastalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            page2 go = new page2();
            go.Show();
            this.Hide();
        }

        private void doktorlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doktorlar go = new doktorlar();
            go.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "yasort";
            SqlDataAdapter dr = new SqlDataAdapter(command);
            DataTable fillData = new DataTable();
            dr.Fill(fillData);
            dataGridView1.DataSource = fillData;

            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "boyortalaması";
            SqlDataAdapter dr = new SqlDataAdapter(command);
            DataTable fillData = new DataTable();
            dr.Fill(fillData);
            dataGridView1.DataSource = fillData;

            conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "yataks";
            SqlDataAdapter dr = new SqlDataAdapter(command);
            DataTable fillData = new DataTable();
            dr.Fill(fillData);
            dataGridView1.DataSource = fillData;
            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "hastayassr";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable fillData = new DataTable();
            dr.Fill(fillData);
            dataGridView1.DataSource = fillData;
        }
    }
}
