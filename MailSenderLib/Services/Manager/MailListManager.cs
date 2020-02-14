using MailSenderLib.Models;
using MailSenderLib.Services.Interfaces.IManager;
using MailSenderLib.Services.Interfaces.IStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Services.Manager
{
    public class MailListManager : IMailListManager
    {
        private IMailStore store;
        public MailListManager(IMailStore Store)
        {
            store = Store;
        }
        public IEnumerable<Mail> GetAll()
        {
            return store.GetAll();
        }
        public void Add(Mail item) 
        {
            store.Create(item);
        }
        public void Edit(Mail item) { }
        public void SaveChanges()
        {
            store.SaveChanges();
        }
        public Mail Remove(int id)
        {
            return store.Remove(id);
        }
    }
}
