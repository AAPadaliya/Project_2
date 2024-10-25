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
    public partial class NewOrder : Form
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

        public NewOrder()
        {
            InitializeComponent();
        }
        private void NewOrderForm_Load(object sender, EventArgs e)
        {
            // Load product data
            DataTable productData = GetProductData();
            cmbProductName.DataSource = productData;
            cmbProductName.DisplayMember = "P_Name";
            cmbProductName.ValueMember = "P_Id";

            // Load supplier data
            DataTable supplierData = GetSupplierData();
            cmbSupplierName.DataSource = supplierData;
            cmbSupplierName.DisplayMember = "S_Name"; // The column name for the supplier name
        }

        private DataTable GetProductData()
        {
            DataTable dt = new DataTable();
            string connectionString = "your_connection_string_here"; // Replace with your connection string

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT P_Id, P_Name FROM Products"; // Replace 'Products' with your actual table name
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            return dt;
        }

        // Example method to retrieve supplier data from the database
        private DataTable GetSupplierData()
        {
            DataTable dt = new DataTable();
            string connectionString = "your_connection_string_here"; // Replace with your connection string

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT S_Number, S_Name FROM Suppliers"; // Replace 'Suppliers' with your actual table name
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            return dt;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
