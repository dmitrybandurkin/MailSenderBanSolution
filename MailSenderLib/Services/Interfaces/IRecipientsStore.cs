using System;
using System.Collections.Generic;
using System.Text;
using MailSenderLib.Models;

namespace MailSenderLib.Services.Interfaces
{
    public interface IRecipientsStore
    {
        IEnumerable<Recipient> GetAll();

        Recipient GetById(int id);

        int Create(Recipient recipient);
        void Edit(int id, Recipient recipient);

        void SaveChanges();

        Recipient Remove(int id);
    }
}
