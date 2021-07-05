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
    public partial class Split : Form
    {
        public Split()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Поле пустое!");
                textBox1.Focus();
            }
            else
            {
                string[] words = textBox1.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in words)
                {
                    textBox3.Text = textBox3.Text + s + "\r\n";
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void Split_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

    }
}
