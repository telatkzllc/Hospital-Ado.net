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
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.ConstrainedExecution;

namespace _12._08._2023
{
    public partial class doktorlar : Form
    {
        public doktorlar()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("server =.;Database=hastane;Integrated Security=true;");
        private void doktorlar_Load(object sender, EventArgs e)
        {
        }
        public void listele()
        {

            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "doktorlist";
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
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "doktorekle";
            command.Parameters.AddWithValue("doktoradsoyad", textBox1.Text);
            command.Parameters.AddWithValue("doktorbrans", textBox2.Text);
            command.Parameters.AddWithValue("doktormaas", textBox3.Text);
            command.Parameters.AddWithValue("doktorprim", textBox4.Text);
            command.Parameters.AddWithValue("polno", textBox5.Text);
            command.ExecuteNonQuery();

            listele();
            temizleme();
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["doktorno"].Value.ToString();
            textBox1.Text = satir.Cells["doktoradsoyad"].Value.ToString();
            textBox2.Text = satir.Cells["doktorbrans"].Value.ToString();
            textBox3.Text = satir.Cells["doktormaas"].Value.ToString();
            textBox4.Text = satir.Cells["doktorprim"].Value.ToString();
            textBox5.Text = satir.Cells["polno"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "doktorsil";
            command.Parameters.AddWithValue("@doktorno", textBox1.Tag);
            command.ExecuteNonQuery();
            MessageBox.Show(" Silme İşlemi Başarılı");
            listele();
            temizleme();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "doktorupdate";
            command.Parameters.AddWithValue("doktorno", textBox1.Tag);
            command.Parameters.AddWithValue("doktoradsoyad", textBox1.Text);
            command.Parameters.AddWithValue("doktorbrans", textBox2.Text);
            command.Parameters.AddWithValue("doktormaas", textBox3.Text);
            command.Parameters.AddWithValue("doktorprim", textBox4.Text);
            command.Parameters.AddWithValue("polno", textBox5.Text);
            command.ExecuteNonQuery();
            MessageBox.Show(" güncelleme İşlemi Başarılı");
            listele();
            temizleme();
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "uzmansayi";
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
            command.CommandText = "doktormaas";
            command.Parameters.AddWithValue("@baslangic", 15000);
            command.Parameters.AddWithValue("@bitis", 80000);
            SqlDataAdapter dr = new SqlDataAdapter(command);
            DataTable fillData = new DataTable();
            dr.Fill(fillData);
            dataGridView1.DataSource = fillData;

            conn.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "unvanagoremaas";
            SqlDataAdapter dr = new SqlDataAdapter(command);
            DataTable fillData = new DataTable();
            dr.Fill(fillData);
            dataGridView1.DataSource = fillData;
            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Ad Soyad")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "doktorara";
                cmd.Parameters.AddWithValue("doktoradsoyad", textBox1.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                conn.Close();
                //buradan aşağısına stored procedure yapılmalıdır.
            }
            else if (comboBox1.SelectedItem == "Bolum")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DoktorAraBolum";
                cmd.Parameters.AddWithValue("doktorBolum", textBox2.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                conn.Close();
            }
            else if (comboBox1.SelectedItem == "Unvan")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DoktorAraUnvan";
                cmd.Parameters.AddWithValue("doktorUnvan", textBox3.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                conn.Close();
            }
            else if (comboBox1.SelectedItem == "PoliNo")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DoktorAraPoliNo";
                cmd.Parameters.AddWithValue("poliklinikNo", textBox4.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                conn.Close();
            }
            else
            {
                MessageBox.Show("Arama Kriteri Giriniz!");
            }


        }

        private void button9_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "doktormaas";
            command.Parameters.AddWithValue("@baslangic",textBox6.Text);
            command.Parameters.AddWithValue("@bitis",textBox7.Text);
            SqlDataAdapter dr = new SqlDataAdapter(command);
            DataTable fillData = new DataTable();
            dr.Fill(fillData);
            dataGridView1.DataSource = fillData;

            conn.Close();
        }
        private void button9_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "doktormaas";
            command.Parameters.AddWithValue("@baslangic", textBox6.Text);
            command.Parameters.AddWithValue("@bitis", textBox7.Text);
            SqlDataAdapter dr = new SqlDataAdapter(command);
            DataTable fillData = new DataTable();
            dr.Fill(fillData);
            dataGridView1.DataSource = fillData;
            conn.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = conn;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "doktormaassıra";
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable fillData = new DataTable();
            dr.Fill(fillData);
            dataGridView1.DataSource = fillData;
        }
    }
}
