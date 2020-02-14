using MailSenderLib.Models;
using System.Collections.Generic;
using MailSenderLib.Services.Interfaces;
using MailSenderLib.Services.Interfaces.IManager;
using MailSenderLib.Services.Interfaces.IStore;

namespace MailSenderLib.Services.Manager
{
    public class ServersManager : IServersManager
    {
        private IServersStore store;
        public ServersManager(IServersStore Store)
        {
            store = Store;
        }
        public IEnumerable<Server> GetAll()
        {
            return store.GetAll();
        }
        public void Add(Server item) { }
        public void Edit(Server item) { }
        public void SaveChanges()
        {
            store.SaveChanges();
        }
        public Server Remove(int id)
        {
            return store.Remove(id);
        }
    }
}
