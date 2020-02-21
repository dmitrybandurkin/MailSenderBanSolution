using MailSenderLib.Data;
using MailSenderLib.Models;
using MailSenderLib.Services.Interfaces;
using MailSenderLib.Services.Interfaces.IStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Services.InMemory
{
    public class ServersStoreInMemory : DataStoreInMemory<Server>, IServersStore
    {
        public ServersStoreInMemory() : base(DataStorage.Servers) 
        {
            System.Diagnostics.Debug.WriteLine("5");
        }
        public override void Edit(int id, Server item)
        {
            
        }
    }
}
