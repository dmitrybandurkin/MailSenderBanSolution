﻿using MailSenderLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MailSenderLib.Services.Interfaces;

namespace MailSenderLib.Services
{
    public class RecipientsManager:IRecipientsManager
    {
        private IRecipientsStore store;
        public RecipientsManager(IRecipientsStore Store)
        {
            this.store = Store;
        }
        public IEnumerable<Recipient> GetAll()
        {
            return store.Get();
        }

        public void Add(Recipient NewRecipient)
        {

        }

        public void Edit(Recipient recipient)
        {
            store.Edit(recipient.Id, recipient);
        }

        public void SaveChanges()
        {
            store.SaveChanges();
        }

        public void Delete(Recipient recipient)
        {
            //TODO
        }

    }
}
