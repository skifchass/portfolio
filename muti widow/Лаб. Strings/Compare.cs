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
    public partial class Compare : Form
    {
        public Compare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Поля пустые!");
                textBox1.Focus();
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("1 поле пустое!");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("2 поле пустое!");
                textBox2.Focus();
            }
            else
            {
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                if (String.Compare(textBox1.Text, textBox2.Text) == 0)
                {
                    textBox4.Text = textBox1.Text + " " + textBox2.Text;
                }
                else if (String.Compare(textBox1.Text, textBox2.Text) > 0)
                {
                    textBox5.Text = textBox1.Text + " " + textBox2.Text;
                }
                else if (String.Compare(textBox1.Text, textBox2.Text) < 0)
                {
                    textBox6.Text = textBox1.Text + " " + textBox2.Text;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void Compare_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }
    }
}
