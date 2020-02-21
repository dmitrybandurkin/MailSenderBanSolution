using MailSenderLib.Models;
using MailSenderLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading;

namespace MailSenderLib.Services.Manager
{
    public class MessageSenderManager : IMessageSender
    {
         public void SendEMail(Sender From, Recipient To, Server Server, Mail Mail, SecureString Password)
        {
            Debug.WriteLine($"Sender_Address:{From.Address}\nRecipient_Address:{To.Address}\nSubject:{Mail.Subject}\nBody:{Mail.Body}\nPort:{Server.Port}\nHost:{Server.Address}\nLogin:{Server.Login}\nPassword:{Password}");

            //using (MailMessage mail = new MailMessage(From, To))
            //{
            //    mail.Subject = Subject;
            //    mail.Body = Body;

            //    try
            //    {
            //        using (SmtpClient smtp = new SmtpClient(Host, Port))
            //        {
            //            smtp.Credentials = new NetworkCredential(Login, Password);
            //            smtp.EnableSsl = true;
            //            smtp.Send(mail);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //= $"Ошибка при отправке письма {ex.Message}";
            //    }
            //}
        }

        public void SendEMailInParallel(Sender From, IEnumerable<Recipient> To, Server Server, Mail Mail, SecureString Password)
        {
            foreach (Recipient recipient in To) ThreadPool.QueueUserWorkItem(o => SendEMail(From, recipient, Server, Mail, Password));
        }
    }
}
