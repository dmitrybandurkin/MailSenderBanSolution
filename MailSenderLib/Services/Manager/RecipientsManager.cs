using MailSenderLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MailSenderLib.Services.Interfaces;

namespace MailSenderLib.Services.Manager
{
    public class RecipientsManager:IRecipientsManager
    {
        private IRecipientsStore store;
        public RecipientsManager(IRecipientsStore Store)
        {
            store = Store;
        }
        public IEnumerable<Recipient> GetAll()
        {
            return store.GetAll();
        }
        public void Add(Recipient item) { }
        public void Edit(Recipient item) { }
        public void SaveChanges()
        {
            store.SaveChanges();
        }
        public Recipient Remove(int id)
        {
            return store.Remove(id);
        }
    }
}
