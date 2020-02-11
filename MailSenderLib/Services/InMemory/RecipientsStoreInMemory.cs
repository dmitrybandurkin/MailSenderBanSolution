using MailSenderLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MailSenderLib.Data;
using System.Linq;
using MailSenderLib.Services.Interfaces;

namespace MailSenderLib.Services.InMemory
{

    public class RecipientsStoreInMemory:DataStoreInMemory<Recipient>,IRecipientsStore
    {
        public RecipientsStoreInMemory() : base(DataStorage.Recipients) { }

        public override void Edit(int id, Recipient item)
        {
            var db_recipient = GetById(id);
            if (db_recipient is null) return;

            db_recipient.Name = item.Name;
            db_recipient.Address = item.Address;
        }
    }
}
