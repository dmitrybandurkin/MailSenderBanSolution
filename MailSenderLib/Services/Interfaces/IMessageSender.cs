using MailSenderLib.Models;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace MailSenderLib.Services.Interfaces
{
    public interface IMessageSender
    {
        void SendEMail(Sender From, Recipient To, Server Server, Mail Mail, SecureString Password);
    }
}
