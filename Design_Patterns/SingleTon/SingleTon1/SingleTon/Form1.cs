using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SingleTon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.Show();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //frmToolBox ftb = frmToolBox.GetInstance();
            //ftb.Show();
            frmToolBox.GetInstance().Show();
        }
    }
}