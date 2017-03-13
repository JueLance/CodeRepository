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

            CompilerParameters 编译参数 = new CompilerParameters(dll);

            编译参数.GenerateExecutable = false;

            编译参数.GenerateInMemory = true;

            string 代码串 = this.textBox1.Text;

            CompilerResults 结果 = CSharp.CompileAssemblyFromSource(编译参数, 代码串);

            Assembly 程序集 = 结果.CompiledAssembly;

            object 动态对象 = 程序集.CreateInstance("wxd");

            MethodInfo 方法 = 动态对象.GetType().GetMethod("setText");

            object[] 参数 = { this.button1 };

            object s = 方法.Invoke(动态对象, 参数);

            System.Console.WriteLine(s);

        }
    }
}