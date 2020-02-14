using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace MailSenderLib.Services.Interfaces
{
    public interface IMessageSender
    {
        void SendEMail(string From, string To, string Subject, string Body, int Port, string Host, string Login, SecureString Password);
    }
}
