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

namespace School_Management_System
{
    public partial class attendance : Form
    {
        public attendance()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

          
            SqlCommand cnn = new SqlCommand("INSERT INTO atab (aid, studentname, status) VALUES (@aid, @studentname, @status)", con);

       
            int aid;
            if (int.TryParse(textBox1.Text, out aid))
            {
                cnn.Parameters.AddWithValue("@aid", aid);  
            }
            else
            {
                
                MessageBox.Show("Please enter a valid number for AId.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return; 
            }

           
            cnn.Parameters.AddWithValue("@studentname", textBox2.Text);
            cnn.Parameters.AddWithValue("@status", textBox3.Text);

           
            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Record Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from atab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();


            SqlCommand cnn = new SqlCommand("UPDATE atab SET studentname = @studentname,status=@status WHERE aid = @aid", con);


            cnn.Parameters.AddWithValue("@aid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@studentname", textBox2.Text);
            cnn.Parameters.AddWithValue("@status", textBox3.Text);
           

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();


            SqlCommand cnn = new SqlCommand("DELETE FROM atab WHERE aid = @aid", con);


            cnn.Parameters.AddWithValue("@aid", int.Parse(textBox1.Text));
            cnn.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from atab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void attendance_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from atab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
