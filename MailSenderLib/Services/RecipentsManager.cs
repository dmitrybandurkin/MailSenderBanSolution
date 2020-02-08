using MailSenderLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MailSenderLib.Services.Interfaces;

namespace MailSenderLib.Services
{
    public class RecipentsManager
    {
        private RecipientsStoreInMemory store;
        public RecipentsManager(RecipientsStoreInMemory Store)
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

    //Edit(Recipient)
    //Delete(Recipient)
    }
}
