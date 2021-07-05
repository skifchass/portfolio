using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                comboBox1.Items.Add(comboBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != "") && (textBox11.Text != "") && (comboBox1.Text != ""))
            {
                try
                {
                    int a = Convert.ToInt32(textBox2.Text);
                    int b = Convert.ToInt32(textBox11.Text);

                    textBox3.Text = comboBox1.Text.Remove(a,b);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Исправьте данные!");
                }
            }
            else
            {
                MessageBox.Show("Введите параметры!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox5.Text != "") && (textBox12.Text != "") && (comboBox1.Text != ""))
            {
                try
                {
                    int a = Convert.ToInt32(textBox5.Text);

                    textBox4.Text = comboBox1.Text.Insert(a, textBox12.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Исправьте данные!");
                }
            }
            else
            {
                MessageBox.Show("Введите параметры!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((textBox7.Text != "") && (textBox13.Text != "") && (comboBox1.Text != ""))
            {
                try
                {
                    int a = Convert.ToInt32(textBox7.Text);
                    int b = Convert.ToInt32(textBox13.Text);

                    textBox6.Text = comboBox1.Text.Substring(a, b);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Исправьте данные!");
                }
            }
            else
            {
                MessageBox.Show("введите параметры!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((textBox9.Text != "") && (comboBox1.Text != ""))
            {
                try
                {
                    textBox8.Text = Convert.ToString(comboBox1.Text.IndexOf(textBox9.Text));
                }
                catch (FormatException)
                {
                    MessageBox.Show("Исправьте данные!");
                }
            }
            else
            {
                MessageBox.Show("Введите параметры!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox10.Text = Convert.ToString(comboBox1.Text.Length);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(textBox3.Text);
                streamWriter.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(textBox4.Text);
                streamWriter.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(textBox6.Text);
                streamWriter.Close();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(textBox8.Text);
                streamWriter.Close();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(textBox10.Text);
                streamWriter.Close();
            }
        }

        
    }
}
