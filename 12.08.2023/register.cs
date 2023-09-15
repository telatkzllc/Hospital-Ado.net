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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("server =.;Database=hastane;Integrated Security=true;");
        public void temizleme()
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "yoneticiekle";
                command.Parameters.AddWithValue("@yoneticino", textBox1.Text);
                command.Parameters.AddWithValue("@yoneticiad", textBox2.Text);
                command.ExecuteNonQuery();
                temizleme();
                conn.Close();
                Form1 go = new Form1();
                go.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Düzgün Giriniz");
            }
        }
    }
}
