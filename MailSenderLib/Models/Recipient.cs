using System;
using System.Collections.Generic;
using System.Text;
using MailSenderLib.Models.Base;

namespace MailSenderLib.Models
{
    public class Recipient: PersonEntity
    {
        public Recipient(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}
