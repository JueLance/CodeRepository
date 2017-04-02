using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Observer2
{
    public partial class LabelEx : UserControl
    {
        private Subject _subject;

        public Subject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public LabelEx()
        {
            InitializeComponent();
        }


        public void ShowConsole()
        {
            if (_subject != null)
            {
                label1.Text = string.Format("{0},输出调试信息", _subject.SubjectAction);
            }
        }
    }
}
