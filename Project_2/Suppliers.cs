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
    public partial class Suppliers : Form
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

                string query = "SELECT S_Name,Product,S_Mail,S_Number from Supplier ";

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
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        public Suppliers()
        {
            InitializeComponent();

        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            LoadProductData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Connection();

            AddSuppliers form4 = new AddSuppliers();
            form4.Show();
        }
    }
}
