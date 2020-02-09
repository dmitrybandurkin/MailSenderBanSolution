using MailSenderLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MailSenderLib.Data;
using System.Linq;

namespace MailSenderLib.Services.Interfaces
{
    public class RecipientsStoreInMemory:IRecipientsStore
    {
        public IEnumerable<Recipient> GetAll() => DataStorage.Recipients;

        public void Edit(int id, Recipient recipient)
        {
            //вся эта фигня для работы с базой данных
            var db_recipient = GetById(id);
            if(db_recipient is null) return;

            db_recipient.Name = recipient.Name;
            db_recipient.Address = recipient.Address;
        }

        public void SaveChanges()
        {
            System.Diagnostics.Debug.WriteLine("Сохранение в списке получателей");
        }

        public Recipient GetById(int id) => DataStorage.Recipients.FirstOrDefault(r => r.Id == id);
        
        public int Create(Recipient recipient)
        {
            if (DataStorage.Recipients.Contains(recipient)) return recipient.Id;
            recipient.Id = DataStorage.Recipients.Count == 0 ? 1 : DataStorage.Recipients.Max(r => r.Id) + 1;
            DataStorage.Recipients.Add(recipient);
            return recipient.Id;
        }

        public Recipient Remove(int id)
        {
            var db_recipient = GetById(id);
            if (db_recipient != null)
                DataStorage.Recipients.Remove(db_recipient);
            return db_recipient;
        }
    }
}
