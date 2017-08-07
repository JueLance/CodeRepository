using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EventEmail
{
    /// <summary>
    /// 手机
    /// </summary>
    public class CallPhone
    {
        private TextBox _tBox;
        public CallPhone(MailManager mm, TextBox tBox)
        {
            mm.MailMsgReceived += new MailMsgEventHandler(CellPhoneMsg);
            _tBox = tBox;
        }

        private void CellPhoneMsg(Object sender, MailMsgEventArgs e)
        {
            _tBox.Text += string.Format("消息到手机：{4}来自:{0}{4}发到:{1}{4}主题:{2}{4}内容:{3}{4}{4}", e.from, e.to, e.subject, e.body,Environment.NewLine);
        }

        public void Register(MailManager mm)
        {
            mm.MailMsgReceived += new MailMsgEventHandler(CellPhoneMsg);
        }
        public void UnRegister(MailManager mm)
        {
            mm.MailMsgReceived -= new MailMsgEventHandler(CellPhoneMsg);
        }
    }
}
