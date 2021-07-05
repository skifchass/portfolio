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
    public partial class Concat : Form
    {
        public Concat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Поля пустые!");
                textBox1.Focus();
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("1 строка пустая!");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("2 строка пустая!");
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("3 строка пустая!");
                textBox3.Focus();
            }
            else
            {
                textBox4.Text = textBox1.Text + " " + textBox2.Text;
                textBox5.Text = String.Concat(textBox1.Text, textBox2.Text);
                string[] value = new string[] { textBox1.Text, textBox2.Text, textBox3.Text };
                textBox6.Text = String.Join(" ", value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void Concat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }
    }
}
