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

namespace School_Management_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            diaplay();
            diaplay1();
            diaplay2();
            diaplay3();

        }

        private void diaplay()
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            try
            {
               
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM studentab", con);  
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());

                
                lblCount.Text = count.ToString();
            }
            catch (SqlException ex)
            {
               
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
             
                con.Close();
            }


        }

        private void diaplay1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM subtab", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lblCount1.Text = Convert.ToString(count.ToString());

            }
            else
            {
                lblCount1.Text = "0";
            }

            con.Close();

        }

        private void diaplay2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM teachertab", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lblCount2.Text = Convert.ToString(count.ToString());

            }
            else
            {
                lblCount2.Text = "0";
            }

            con.Close();

        }

        private void diaplay3()
        {
            SqlConnection con = new SqlConnection(@"Data Source=HIRUSHA;Initial Catalog=schooldb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM entab", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                lblCount3.Text = Convert.ToString(count.ToString());

            }
            else
            {
                lblCount3.Text = "0";
            }

            con.Close();

        }


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
