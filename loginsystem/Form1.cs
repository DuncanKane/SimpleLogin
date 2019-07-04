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

namespace loginsystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                // connection to database SQL server
                conn.ConnectionString = "Server = PINGWARRIOR-PC; Database = Users; Integrated Security = true;";

                // The connection string below is wrong!!
                //conn.ConnectionString = "Server=[PINGWARRIOR-PC];Database=[Users];Trusted_Connection=true;";
                //conn.Open();
                //send query to DB
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM LoginDetails WHERE Username='"+ textBox1.Text +"' AND Password='"+ textBox2.Text + "'", conn);
                //SqlCommand sda = new SqlCommand("SELECT COUNT(*) FROM UserLogin WHERE UserName='"+ textBox1.Text +"' AND Password='"+ textBox2.Text + "'", conn);
                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);
                conn.Close();
                
                if (dt.Rows[0][0].ToString() == "1")
                {
                    /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                    this.Hide();
                    //new home().Show();
                    Console.WriteLine("Logged in Fam");
                    Console.ReadLine();
                }
                else
                    MessageBox.Show("Invalid username or password");
            }

        }
    }
}
