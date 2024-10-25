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
    public partial class Inventory : Form
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

        private void LoadProductData()
        {
            Connection();

            try
            {
                con = new SqlConnection(s);
                con.Open();

                string query = "SELECT P_ID,P_Name,P_B_Price,P_S_Price,Quantity from Product ";

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
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        public Inventory()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Connection();

            AddProduct form4 = new AddProduct();
            form4.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            LoadProductData();

        }
    }
}
