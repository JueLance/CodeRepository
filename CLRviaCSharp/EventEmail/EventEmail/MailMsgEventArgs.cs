using System;
using System.Collections.Generic;
using System.Text;

namespace EventEmail
{
    /// <summary>
    /// 事件传递的消息定义
    /// </summary>
    public class MailMsgEventArgs : EventArgs
    {
        public readonly string from, to, subject, body;

        public MailMsgEventArgs(string from, string to, string subject, string body)
        {
            this.from = from;
            this.to = to;
            this.subject = subject;
            this.body = body;
        }
    }
}
