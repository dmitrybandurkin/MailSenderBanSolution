using System;
using System.Collections.Generic;
using System.Text;
using MailSenderLib.Models.Base;

namespace MailSenderLib.Models
{
    public class Sender:PersonEntity
    {
        public Sender(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
