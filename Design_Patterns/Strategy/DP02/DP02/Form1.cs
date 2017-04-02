using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DP02.Core;

namespace DP02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CashSuper cs = CashFactory.CreateCashAccept(comboBox1.SelectedItem.ToString());
            lbResult.Text = cs.AcceptCash(double.Parse(textBox1.Text)).ToString();
        }
    }
}
