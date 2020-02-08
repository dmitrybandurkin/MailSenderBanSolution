using MailSenderLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MailSenderLib.Data;

namespace MailSenderLib.Services.Interfaces
{
    public class RecipientsStoreInMemory
    {
        public IEnumerable<Recipient> Get() => DataStorage.Recipients;
    }
}
