using MailSenderLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MailSenderLib.Services.Manager
{
    //public class MessageSenderManager : IMessageSender
    //{
    //    //private string from;
    //    //private string to;
    //    //private string subject;
    //    //private string body;

    //    //public void SendEMail(string From, string To, string Subject, string Body)
    //    //{
    //    //    using (MailMessage mail = new MailMessage(From, To))
    //    //    {
    //    //        mail.Subject = Subject;
    //    //        mail.Body = Body;

    //    //        try
    //    //        {
    //    //            using (SmtpClient smtp = new SmtpClient(Host, Port))
    //    //            {
    //    //                smtp.Credentials = new NetworkCredential(Login, Password);
    //    //                smtp.EnableSsl = true;
    //    //                smtp.Send(mail);
    //    //            }
    //    //        }
    //    //        catch (Exception ex)
    //    //        {
    //    //             //= $"Ошибка при отправке письма {ex.Message}";
    //    //        }
    //    //    }
    //    //}
    //}
}
