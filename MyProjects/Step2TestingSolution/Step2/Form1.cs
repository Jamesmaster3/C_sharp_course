using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Step2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            const double TAXRATE = 0.21;
            textBox2.Text = TAXRATE.ToString();
            double subtotal = 0;
            double taxAmount = 0;
            double total = 0;
            int roundedTotal = 0;

            subtotal = Convert.ToDouble(textBox1.Text);
            taxAmount = TAXRATE * subtotal;
            textBox4.Text = taxAmount.ToString();

            total = subtotal + taxAmount;
            textBox3.Text = total.ToString();

            roundedTotal = Convert.ToInt32(total);
            this.Text = roundedTotal.ToString(); // 'This' refers to the whole program in this case, so rounded number is in title bar
        }
    }
}
