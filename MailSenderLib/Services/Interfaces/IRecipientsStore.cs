using System;
using System.Collections.Generic;
using System.Text;
using MailSenderLib.Models;

namespace MailSenderLib.Services.Interfaces
{
    public interface IRecipientsStore
    {
        IEnumerable<Recipient> Get();

        Recipient GetById(int id);

        int Create(Recipient recipient);
        void Edit(int id, Recipient recipient);

        void SaveChanges();

        void Delete(int id);
    }
}
