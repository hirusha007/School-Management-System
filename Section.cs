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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace School_Management_System
{
    public partial class Section : Form
    {
        public Section()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
       
            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("INSERT INTO sectiontab (sectionid, studentname, section) VALUES (@sectionid, @studentname, @section)", con);

            cnn.Parameters.AddWithValue("@sectionid", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@studentname", textBox2.Text);
            cnn.Parameters.AddWithValue("@section", textBox3.Text); 

        
            cnn.ExecuteNonQuery();

          
            con.Close();

   
            MessageBox.Show("Record Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from sectiontab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
         
            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            
            SqlCommand cnn = new SqlCommand("UPDATE sectiontab SET studentname = @studentname, section = @section WHERE sectionid = @sectionid", con);

           
            cnn.Parameters.AddWithValue("@sectionid", int.Parse(textBox1.Text));  
            cnn.Parameters.AddWithValue("@studentname", textBox2.Text);  
            cnn.Parameters.AddWithValue("@section", textBox3.Text);  

            cnn.ExecuteNonQuery();

            con.Close();

        
            MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("DELETE FROM sectiontab WHERE sectionid = @sectionid", con);

            
            cnn.Parameters.AddWithValue("@sectionid", int.Parse(textBox1.Text));

            
            cnn.ExecuteNonQuery();

            
            con.Close();

            MessageBox.Show("Record deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from sectiontab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void Section_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from sectiontab", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
