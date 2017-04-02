using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SingleTon
{
    public partial class frmToolBox : Form
    {
        public frmToolBox()
        {
            InitializeComponent();
        }

        //private static frmToolBox ftb = null;

        //public static frmToolBox GetInstance()
        //{
        //    if (ftb == null || ftb.IsDisposed)
        //    {
        //        ftb = new frmToolBox();
        //        ftb.MdiParent = Form1.ActiveForm;
        //    }
        //    ftb.Activate();
        //    return ftb;
        //}

        private static frmToolBox instance;
        private static readonly object syncRoot = new object();

        public static frmToolBox GetInstance()
        {
            //˫������
            //���ж�ʵ���Ƿ���ڣ��������ټ�������
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new frmToolBox();
                    }
                }
            }
            return instance;
        }
    }
}