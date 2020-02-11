using MailSenderLib.Data;
using MailSenderLib.Models;
using MailSenderLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Services.InMemory
{
    class ServersStoreInMemory : DataStoreInMemory<Server>, IServerStore
    {
        public ServersStoreInMemory() : base(DataStorage.Servers) { }
        public override void Edit(int id, Server item)
        {
            
        }
    }
}
