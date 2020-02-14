using MailSenderLib.Data;
using MailSenderLib.Models;
using MailSenderLib.Services.Interfaces.IStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Services.InMemory
{
    public class MailsStoreInMemory : DataStoreInMemory<Mail>, IMailStore
    {
        public MailsStoreInMemory() : base(DataStorage.Mails) { }
        public override void Edit(int id, Mail item)
        {
            throw new NotImplementedException();
        }
    }
}
