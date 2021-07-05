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
    public partial class Remove : Form
    {
        public Remove()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void Remove_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
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
                MessageBox.Show("Введите строку!");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Введите 1-ую границу!");
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Введите 2-ую границу!");
                textBox3.Focus();
            }
            else
            {
                try
                {
                    if (Convert.ToInt32(textBox2.Text) < 0)
                    {
                        MessageBox.Show("Граница интервала не может быть отрицательной!");
                        textBox2.Focus();
                    }
                    else if (Convert.ToInt32(textBox3.Text) > textBox1.Text.Length)
                    {
                        MessageBox.Show("Интервал очень большой!");
                        textBox3.Focus();
                    }
                    else
                    {
                        textBox5.Text = textBox1.Text.Remove(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
                    }
                }
                catch (FormatException)
                {
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox2.Focus();
                    MessageBox.Show("Границы интервала должны быть целыми числами!");
                }
            }
        }


    }
}
