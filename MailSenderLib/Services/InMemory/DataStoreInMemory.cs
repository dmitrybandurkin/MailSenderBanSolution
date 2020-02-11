﻿using MailSenderLib.Models.Base;
using MailSenderLib.Services.Interfaces;
using MailSenderLib.Services.Interfaces.IStore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MailSenderLib.Services.InMemory
{
    public abstract class DataStoreInMemory<T> : IDataStore<T> where T: BaseEntity
    {
        private readonly ObservableCollection<T> items;

        protected DataStoreInMemory(ObservableCollection<T> Items = null)
        {
            System.Diagnostics.Debug.WriteLine("6");
            items = Items ?? new ObservableCollection<T>();
            System.Diagnostics.Debug.WriteLine("7");
        }

        public IEnumerable<T> GetAll() => items;
        public int Create(T item)
        {
            if (items.Contains(item)) return item.Id;
            item.Id = items.Count == 0 ? 1 : items.Max(r => r.Id) + 1;
            items.Add(item);
            return item.Id;
        }

        public abstract void Edit(int id, T item);

        public T GetById(int id) => items.FirstOrDefault(item => item.Id == id);

        public T Remove(int id)
        {
            var item = GetById(id);
            if (item != null) items.Remove(item);
            return item;
        }

        public void SaveChanges()
        {
            System.Diagnostics.Debug.WriteLine($"Сохранение в списке {typeof(T)}");
        }
    }
}
