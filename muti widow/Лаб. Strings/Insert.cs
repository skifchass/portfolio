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
    public partial class Insert : Form
    {
        public Insert()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void Insert_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "") {
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
                MessageBox.Show("Введите подстроку!");
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Введите позицию!");
                textBox3.Focus();
            }
            else
            {
                try
                {
                    if (Convert.ToInt32(textBox3.Text) < 0)
                    {
                        MessageBox.Show("Позиция очень маленькая!");
                    }
                    else if (Convert.ToInt32(textBox3.Text) <= textBox1.Text.Length)
                    {
                        textBox4.Text = textBox1.Text.Insert(Convert.ToInt32(textBox3.Text), textBox2.Text);
                    }
                    else if (Convert.ToInt32(textBox3.Text) > textBox1.Text.Length)
                    {
                        MessageBox.Show("Позиция очень большая!");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Позиция должна быть целым числом!");
                    textBox3.Focus();
                }
            }
        }

    }
}
