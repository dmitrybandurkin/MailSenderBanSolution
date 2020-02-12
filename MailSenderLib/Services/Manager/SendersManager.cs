using MailSenderLib.Models;
using MailSenderLib.Services.Interfaces.IManager;
using MailSenderLib.Services.Interfaces.IStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Services.Manager
{
    public class SendersManager : ISendersManager
    {
        private ISendersStore store;
        public SendersManager(ISendersStore Store)
        {
            store = Store;
        }
        public IEnumerable<Sender> GetAll()
        {
            return store.GetAll();
        }
        public void Add(Sender item) { }
        public void Edit(Sender item) { }
        public void SaveChanges()
        {
            store.SaveChanges();
        }
        public Sender Remove(int id)
        {
            return store.Remove(id);
        }
    }
}
