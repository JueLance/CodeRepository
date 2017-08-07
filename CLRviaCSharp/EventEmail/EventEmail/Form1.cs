using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EventEmail
{
    public partial class Form1 : Form
    {
        private Fax fax = null;
        private CallPhone cell = null;
        private MailManager mm = null;

        public Form1()
        {
            InitializeComponent();

            mm = new MailManager();

            fax = new Fax(mm, txtReceiver);
            cell = new CallPhone(mm, txtReceiver);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            mm.SimulateArrivingMsg(txtFrom.Text, txtTo.Text, txtSubject.Text, txtBody.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtReceiver.Text = "";
        }

        private void btnFax_Click(object sender, EventArgs e)
        {
            fax.UnRegister(mm);
        }

        private void btnCell_Click(object sender, EventArgs e)
        {
            cell.UnRegister(mm);
        }
    }
}