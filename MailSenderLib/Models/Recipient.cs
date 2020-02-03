using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Models
{
    public class Recipient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Recipient(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}
