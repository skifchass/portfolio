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
    public partial class Search : Form
    {
        public Search()
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
                textBox3.Text = "";
                textBox4.Text = "";
                if (textBox1.Text.IndexOf(textBox2.Text) != -1 && textBox1.Text.LastIndexOf(textBox2.Text) != -1)
                {
                    textBox3.Text = Convert.ToString(textBox1.Text.IndexOf(textBox2.Text));
                    textBox4.Text = Convert.ToString(textBox1.Text.LastIndexOf(textBox2.Text));
                }
                else
                {
                    MessageBox.Show("Элемент не найден");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void Search_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }
    }
}
