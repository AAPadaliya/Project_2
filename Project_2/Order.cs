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
    public partial class Order : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        DataTable dt;

        String s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kevin nandasana\source\repos\Project_2\Project_2\Database1.mdf;Integrated Security = True";

        String i, d;

        void Connection()
        {
            con = new SqlConnection(s);
            con.Open();
        }


        private void LoadData()
        {
            try
            {
                // Establish the database connection
                con = new SqlConnection(s);
                con.Open();

                // SQL query to select products where Quantity is less than 10
                string query = "SELECT ";

                // Execute the query using SqlDataAdapter
                da = new SqlDataAdapter(query, con);
                dt = new DataTable();

                // Fill the DataTable with the data from the database
                da.Fill(dt);

                // Bind the data to DataGridView2
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                // Display any errors that occur
                MessageBox.Show("An error occurred while loading data for DataGridView2: " + ex.Message);
            }
            finally
            {
                // Always close the connection
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

            public Order()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewOrder mainForm = new NewOrder();
            mainForm.Show();
            this.Hide(); // Close the login form
        }

        private void Order_Load(object sender, EventArgs e)
        {

        }
    }
}
