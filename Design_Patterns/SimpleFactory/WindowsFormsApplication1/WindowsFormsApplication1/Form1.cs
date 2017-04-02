using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Calculator;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            //简单工厂
            string op = comboBox1.SelectedItem.ToString();
            Operation opera = OperationFactory.CreateOperation(op);
            opera.NumberA = Convert.ToDouble(tbA.Text);
            opera.NumberB = Convert.ToDouble(tbB.Text);

            tbResult.Text = opera.GetResult().ToString();
        }
    }
}
