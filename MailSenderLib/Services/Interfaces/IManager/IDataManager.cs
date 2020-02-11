using System.Collections.Generic;

namespace MailSenderLib.Services.Interfaces
{
    public interface IDataManager<T>
    {
        IEnumerable<T> GetAll();
        void Add(T item);
        void Edit(T item);
        void SaveChanges();
        T Remove(int id);
    }
}
