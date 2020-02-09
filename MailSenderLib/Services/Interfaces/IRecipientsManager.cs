using System;
using System.Collections.Generic;
using System.Text;
using MailSenderLib.Models;

namespace MailSenderLib.Services.Interfaces
{
    public interface IRecipientsManager
    {
        IEnumerable<Recipient> GetAll();
        void Add(Recipient NewRecipient);
        void Edit(Recipient recipient);
        void SaveChanges();
        Recipient Remove(int id);
    }
}
