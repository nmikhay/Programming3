using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextTotal.Text = TextTotal.Text + button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextTotal.Text = TextTotal.Text + button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextTotal.Text = TextTotal.Text + button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextTotal.Text = TextTotal.Text + button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TextTotal.Text = TextTotal.Text + button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TextTotal.Text = TextTotal.Text + button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TextTotal.Text = TextTotal.Text + button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TextTotal.Text = TextTotal.Text + button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TextTotal.Text = TextTotal.Text + button9.Text;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            TextTotal.Text = TextTotal.Text + button0.Text;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            TextTotal.Text = TextTotal.Text + buttonPlus.Text;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            TextTotal.Text = TextTotal.Text + buttonMinus.Text;
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            TextTotal.Text = TextTotal.Text + buttonMultiply.Text;
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            TextTotal.Text = TextTotal.Text + buttonDivide.Text;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            TextTotal.Text = TextTotal.Text + buttonClear.Text;
        }
    }
}
