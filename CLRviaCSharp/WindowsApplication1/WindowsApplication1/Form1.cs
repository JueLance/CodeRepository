using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CSharpCodeProvider CSharp = new CSharpCodeProvider();

            String[] dll = { "System.dll", "System.Windows.Forms.dll" };

            CompilerParameters ������� = new CompilerParameters(dll);

            �������.GenerateExecutable = false;

            �������.GenerateInMemory = true;

            string ���봮 = this.textBox1.Text;

            CompilerResults ��� = CSharp.CompileAssemblyFromSource(�������, ���봮);

            Assembly ���� = ���.CompiledAssembly;

            object ��̬���� = ����.CreateInstance("wxd");

            MethodInfo ���� = ��̬����.GetType().GetMethod("setText");

            object[] ���� = { this.button1 };

            object s = ����.Invoke(��̬����, ����);

            System.Console.WriteLine(s);

        }
    }
}