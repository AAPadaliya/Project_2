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
    public partial class AddProduct : Form
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

        public AddProduct()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            {
                Connection();

                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
                {
                    MessageBox.Show("Please enter both email and password.");
                    return;
                }
                else
                {
                    cmd = new SqlCommand("insert into Product(P_Name,P_Id,P_S_Price,P_B_price,Quantity)values( '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
                    cmd.ExecuteNonQuery();

                    this.Close();
                }

            }
        }
    }
}
