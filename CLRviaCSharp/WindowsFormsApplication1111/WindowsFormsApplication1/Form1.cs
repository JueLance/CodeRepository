using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using ClassLibrary1;
using System.Runtime.Remoting;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            string dll = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ClassLibrary1.dll");

            //label1.Text = AppDomain.CurrentDomain.BaseDirectory;
            Assembly assembly = Assembly.LoadFrom(dll);
            Type[] types = assembly.GetTypes();

            if (types.Length > 0)
            {
                comboBox1.Items.AddRange(types);
            }

            //ObjectHandle s = Activator.CreateInstanceFrom(dll, comboBox1.SelectedItem.ToString());
            //s.


            //Type type = Type.GetType("ClassLibrary1");
            //MemberInfo[] infos = type.GetMembers();
            //foreach (var item in infos)
            //{
            //    comboBox1.Items.Add(item.Name);
            //}


            //Assembly[] assemblys = AppDomain.CurrentDomain.GetAssemblies();
            //comboBox1.Items.AddRange(assemblys);

            //AssemblyName[] assemblys = System.Reflection.Assembly.GetEntryAssembly().GetReferencedAssemblies();
            //comboBox1.Items.AddRange(assemblys);


            //Type objType = Type.GetType("ClassLibrary1.Employee", true);
            //Employee obj = (Employee)Activator.CreateInstance(objType);
            //label2.Text = obj.GetSalary().ToString();

            //Assembly myAssembly = Assembly.LoadFrom(dll);
            //Module[] modules = myAssembly.GetModules();
            //comboBox1.Items.AddRange(modules);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type type = Type.GetType(comboBox1.SelectedValue.ToString(), true);
            //label2.Text = type.Name;
        }
    }
}
