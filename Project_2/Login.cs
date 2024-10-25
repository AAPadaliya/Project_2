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
using System.Data;
using System.IO;

namespace Project_2
{
    public partial class Login : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        String s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kevin nandasana\source\repos\Stock management system\Stock management system\stock.mdf;Integrated Security = True";

        String i, d;

        void Connection()
        {
            con = new SqlConnection(s);
            con.Open();
        }

        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateAccount form2 = new CreateAccount();
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = e_mail.Text;
            string password = e_pass.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            // Replace 's' with your actual connection string
            using (SqlConnection conn = new SqlConnection(s))
            {
                try
                {
                    conn.Open();
                    // SQL query to check if email and password match
                    string query = "SELECT COUNT(1) FROM Admin WHERE Admin = @Admin AND Passworrd = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Use parameterized query to avoid SQL injection
                        cmd.Parameters.AddWithValue("@Admin", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        // Execute the query and get the result
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 1)
                        {
                            MessageBox.Show("Login successful!");
                            // You can open the next form after successful login
                            Form1 form3 = new Form1();
                            form3.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
