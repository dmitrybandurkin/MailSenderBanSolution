using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Windows;

namespace MailSenderBan
{
    public class WPFMailSender
    {
        MailMessage mail;
        string login;
        string password;
        int port;
        string host;

        public WPFMailSender(string log, string pass, int port, string host)
        {
            login = log;
            password = pass;
            this.port = port;
            this.host = host;
        }

        public void SendEMail(string from, string to, string subject, string body)
        {
            mail = new MailMessage(from, to);
            mail.Subject = subject;
            mail.Body = body;

            try
            {
                SmtpClient smtp = new SmtpClient(host, port);
                smtp.Credentials = new NetworkCredential(login, password);
                smtp.EnableSsl = true;
                smtp.Send(mail);

                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
