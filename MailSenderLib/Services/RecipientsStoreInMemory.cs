using MailSenderLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MailSenderLib.Data;

namespace MailSenderLib.Services.Interfaces
{
    public class RecipientsStoreInMemory:IRecipientsStore
    {
        public IEnumerable<Recipient> Get() => DataStorage.Recipients;

        public void Edit(int id, Recipient recipient)
        {
            //нет базы данных
        }

        public void SaveChanges()
        {
            //нет базы данных
        }

    }
}
