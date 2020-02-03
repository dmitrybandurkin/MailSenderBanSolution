using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Windows;
using System.Security;
using System.Windows.Controls;

namespace MailSenderBan
{
    public class WPFMailSender
    {
        string login;
        //string password;
        SecureString password;
        int port;
        string host;

        public WPFMailSender(string log, SecureString pass, int port, string host)
        {
            login = log;
            password = pass;
            this.port = port;
            this.host = host;
        }

        public void SendEMail(string from, string to, string subject, string body, TextBlock block)
        {
            using (MailMessage mail = new MailMessage(from, to))
            {


                mail.Subject = subject;
                mail.Body = body;

                try
                {
                    using (SmtpClient smtp = new SmtpClient(host, port))
                    {
                        smtp.Credentials = new NetworkCredential(login, password);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }

                    block.Text = "Письмо успешно отправлено";
                }
                catch (Exception ex)
                {
                    block.Text = $"Ошибка при отправке письма {ex.Message}";
                }
            }
        }
    }
}
