using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EventEmail
{
    /// <summary>
    /// 传真机
    /// </summary>
    public class Fax
    {
        private TextBox _tBox;
        public Fax(MailManager mm, TextBox tBox)
        {
            //监听事件　
            //这里的FaxMsg，指的是符合MailMsgEventHandler委托的方法，也就是激发事件后所执行的方法
            mm.MailMsgReceived += new MailMsgEventHandler(FaxMsg);
            _tBox = tBox;
        }

        private void FaxMsg(Object sender, MailMsgEventArgs e)
        {
            _tBox.Text += string.Format("消息到传真：{4}来自:{0}{4}发到:{1}{4}主题:{2}{4}内容:{3}{4}{4}", e.from, e.to, e.subject, e.body, Environment.NewLine);
        }

        public void Register(MailManager mm)
        {
            mm.MailMsgReceived += new MailMsgEventHandler(FaxMsg);
        }

        public void UnRegister(MailManager mm)
        {
            //注销事件
            mm.MailMsgReceived -= new MailMsgEventHandler(FaxMsg);
        }
    }
}
