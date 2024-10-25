using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void AddControl(Form f)
        {
            CenterPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            CenterPanel.Controls.Add(f);
            f.Show();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            AddControl(new Dashboard());
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddControl(new Inventory());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddControl(new Suppliers());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddControl(new Order());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddControl(new Sales());
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            AddControl(new Dashboard());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login form3 = new Login();
            form3.Show();
            this.Hide();
        }
    }
}
