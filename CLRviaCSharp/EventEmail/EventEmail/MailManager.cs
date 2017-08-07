using System;
using System.Collections.Generic;
using System.Text;

namespace EventEmail
{
    public class MailManager
    {
        public event MailMsgEventHandler MailMsgReceived;

        /// <summary>
        /// 激发事件
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMailMsg(MailMsgEventArgs e)
        {
            if (this.MailMsgReceived != null)
            {
                MailMsgReceived(this, e);
            }
        }

        //通过事件传递消息
        public void SimulateArrivingMsg(string from, string to, string subject, string body)
        {
            MailMsgEventArgs e = new MailMsgEventArgs(from, to, subject, body);
            OnMailMsg(e);
        }
    }
}


