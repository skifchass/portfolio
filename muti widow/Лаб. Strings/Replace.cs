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
    public partial class Replace : Form
    {
        public Replace()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void Replace_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox1.Text == "" && textBox1.Text == "") {
                MessageBox.Show("Поля пустые!");
                textBox1.Focus();
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Введите строку!");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Введите что надо заменить!");
                textBox2.Focus();
            }
            else
            {
                textBox5.Text = textBox1.Text.Replace(textBox2.Text, textBox3.Text);
            }
        }

    }
}
