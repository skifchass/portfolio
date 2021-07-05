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
    public partial class Trim : Form
    {
        public Trim()
        {
            InitializeComponent();
        }

        private void Trim_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Поле пустое!");
                textBox1.Focus();
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите действие!");
                comboBox1.Focus();
            }
            else
            {
                if (comboBox1.SelectedIndex == 1)
                {
                    try
                    {
                        if (Convert.ToInt32(textBox2.Text) <= 0)
                        {
                            MessageBox.Show("Граница интервала не может быть меньше 1!");
                            textBox2.Focus();
                        }
                        else if (Convert.ToInt32(textBox3.Text) <= textBox1.Text.Length)
                        {
                            if (Convert.ToInt32(textBox2.Text) < Convert.ToInt32(textBox3.Text))
                            {
                                string text = textBox1.Text.Substring(Convert.ToInt32(textBox2.Text) - 1, Convert.ToInt32(textBox3.Text));
                                textBox6.Text = text;
                            }
                            else
                            {
                                MessageBox.Show("Первая граница должна быть меньше второй");
                            }
                        }
                        else if (Convert.ToInt32(textBox3.Text) > textBox1.Text.Length)
                        {
                            MessageBox.Show("Интервал очень большой!");
                            textBox3.Focus();
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
                else if (comboBox1.SelectedIndex == 0)
                {
                    if (textBox4.Text == "")
                    {
                        MessageBox.Show("Поле пустое!");
                        textBox4.Focus();
                    }
                    else
                    {
                        string text = textBox4.Text.Trim();
                        textBox6.Text = textBox1.Text.Trim(text[0]);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox4.ReadOnly = false;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = true;
            }
        }

        private void Trim_Load(object sender, EventArgs e)
        {
            textBox4.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
        }
    }
}
