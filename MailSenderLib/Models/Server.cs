using System;
using MailSenderLib.Models.Base;

namespace MailSenderLib
{
    public class Server:NamedEntity
    {
        public bool SslEnable { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Server(string name, string address, int port, string login, string password, bool ssl = true)
        {
            Name = name;
            Address = address;
            Port = port;
            Login = login;
            Password = password;
            SslEnable = ssl;
        }
    }
}
