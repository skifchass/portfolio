﻿using System;
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
    public partial class RegChange : Form
    {
        public RegChange()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void RegChange_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите строку!");
                textBox1.Focus();
            }
            textBox3.Text = textBox1.Text.ToUpper();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите строку!");
                textBox1.Focus();
            }
            textBox3.Text = textBox1.Text.ToLower();
        }
    }
}
