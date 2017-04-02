/*
 * 
 * 建造者模式
 * 
 * 将一个复杂对象的构建与表示相分离。使得同样的构建过程可以创建不同的表示。
 * 
 * 
 * **/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BuilderPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red);
            PersonBuilder thin = new ThinPerson(e.Graphics, pen);
            PersonBuilder fat = new FatPerson(e.Graphics, pen);

            BuildDirector director = new BuildDirector(thin);
            director.DrawPerson();

            BuildDirector director2 = new BuildDirector(fat);
            director2.DrawPerson();
        }
    }
}
