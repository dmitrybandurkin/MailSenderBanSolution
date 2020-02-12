using MailSenderLib.Data;
using MailSenderLib.Models;
using MailSenderLib.Services.Interfaces.IStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Services.InMemory
{
    public class SendersStoreInMemory : DataStoreInMemory<Sender>, ISendersStore
    {
        public SendersStoreInMemory() : base(DataStorage.Senders) { }
        public override void Edit(int id, Sender item)
        {
        }
    }
}
