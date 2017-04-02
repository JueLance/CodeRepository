using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Observer2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boss boss = new Boss();

            labelEx1.Subject = boss;
            labelEx21.Subject = boss;

            boss.Update += new UpdateEventHandler(labelEx1.ShowConsole);
            boss.Update += new UpdateEventHandler(labelEx21.ShowInfo);

            boss.SubjectAction = "我回来了";
            boss.Notify();
        }

      
    }
}
