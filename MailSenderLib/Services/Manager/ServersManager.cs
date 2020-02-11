using MailSenderLib.Models;
using System.Collections.Generic;
using MailSenderLib.Services.Interfaces;
using MailSenderLib.Services.Interfaces.IManager;

namespace MailSenderLib.Services.Manager
{
    public class ServersManager : IServersManager
    {
        private IServersManager store;
        public ServersManager(IServersManager Store)
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
