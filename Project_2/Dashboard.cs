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
    public partial class Dashboard : Form
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
        public Dashboard()
        {
            InitializeComponent();
            LoadData();

        }

        private void LoadData()
        {
            try
            {
                // Establish the database connection
                con = new SqlConnection(s);
                con.Open();

                // SQL query to select products where Quantity is less than 10
                string query = "SELECT P_Name AS [Product Name], Quantity FROM Product WHERE Quantity < 10";

                // Execute the query using SqlDataAdapter
                da = new SqlDataAdapter(query, con);
                dt = new DataTable();

                // Fill the DataTable with the data from the database
                da.Fill(dt);

                // Bind the data to DataGridView2
                dataGridView2.DataSource = dt;
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


            //______________________________________________________
            try
            {
                using (SqlConnection connection = new SqlConnection(s))
                {
                    connection.Open();
                    string query = "SELECT COUNT(DISTINCT S_Name) FROM Supplier";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int supplierCount = (int)command.ExecuteScalar(); // ExecuteScalar returns the first column of the first row.
                        textBox4.Text = supplierCount.ToString(); // Assuming txtNumberOfSuppliers is a TextBox or Label
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            DisplayTotalPurchase();
        }

        private void DisplayTotalPurchase()
        {
            try
            {
                // Establish the database connection
                con = new SqlConnection(s);
                con.Open();

                // SQL query to calculate the sum of Quantity
                string query = "SELECT SUM(Quantity) FROM Product";

                // Execute the query
                cmd = new SqlCommand(query, con);
                var result = cmd.ExecuteScalar();

                // Check if the result is not null, then display it in the lblPurchase label
                if (result != DBNull.Value)
                {
                    textBox2.Text = result.ToString();
                }
                else
                {
                    textBox2.Text = "0";
                }
            }
            catch (Exception ex)
            {
                // Display any errors that occur
                MessageBox.Show("An error occurred while fetching the total purchase: " + ex.Message);
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
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
