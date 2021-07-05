using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаб.Strings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Concate = new Concat();
            Concate.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Compare = new Compare();
            Compare.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form Trim = new Trim();
            Trim.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form RegChange = new RegChange();
            RegChange.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form Replace = new Replace();
            Replace.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Search = new Search();
            Search.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form Split = new Split();
            Split.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form Insert = new Insert();
            Insert.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form Remove = new Remove();
            Remove.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
