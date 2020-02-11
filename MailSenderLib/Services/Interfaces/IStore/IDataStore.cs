using System;
using System.Collections.Generic;
using System.Text;

namespace MailSenderLib.Services.Interfaces.IStore
{
    /// <summary>
    /// хранилище объектов
    /// </summary>
    /// <typeparam name="T">тип хранимого объекта</typeparam>
    public interface IDataStore<T>
    {
        /// <summary>
        /// получить все объекты
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// получить объект по идентификатору
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns></returns>
        T GetById(int id);
        /// <summary>
        /// создать объект
        /// </summary>
        /// <param name="item">объект</param>
        /// <returns>найденный объект, либо <see langword="null"</returns>
        int Create(T item);
        /// <summary>
        /// внести изменения в объект
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="item">модель данных, которые хотим изменить</param>
        void Edit(int id, T item);
        /// <summary>
        /// сохранить объект
        /// </summary>
        void SaveChanges();
        /// <summary>
        /// удалить объект
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>удаленный объект, либо <see langword="null"/> если объекта в хранилище не было</returns>
        T Remove(int id);
    }
}
