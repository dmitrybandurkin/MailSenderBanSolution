using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Windows;
using System.Security;

namespace MailSenderLib.Services
{
    public class SendService
    {
        string login;
        string password;
        int port;
        string host;

        public SendService(string log, string pass, int port, string host)
        {
            login = log;
            password = pass;
            this.port = port;
            this.host = host;
        }

        public void SendEMail(string from, string to, string subject, string body)
        {
            using (MailMessage mail = new MailMessage(from, to))
            {


                mail.Subject = subject;
                mail.Body = body;
                using (SmtpClient smtp = new SmtpClient(host, port))
                {
                    smtp.Credentials = new NetworkCredential(login, password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
