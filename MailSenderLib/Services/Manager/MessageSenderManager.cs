using MailSenderLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;

namespace MailSenderLib.Services.Manager
{
    public class MessageSenderManager : IMessageSender
    {
         public void SendEMail(string From, string To, string Subject, string Body, int Port, string Host, string Login, SecureString Password)
        {
            Debug.WriteLine($"Sender_Address:{From}\nRecipient_Address:{To}\nSubject:{Subject}\nBody:{Body}\nPort:{Port}\nHost:{Host}\nLogin:{Login}\nPassword:{Password}");

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
    }
}
