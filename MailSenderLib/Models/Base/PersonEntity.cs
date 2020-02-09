using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Models.Base
{
    public abstract class PersonEntity:NamedEntity
    {
        public string Address { get; set; }
    }
}
