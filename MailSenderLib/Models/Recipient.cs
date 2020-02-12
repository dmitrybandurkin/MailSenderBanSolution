using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MailSenderLib.Models.Base;

namespace MailSenderLib.Models
{
    public class Recipient: PersonEntity, IDataErrorInfo
    {
        public Recipient(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        string IDataErrorInfo.this[string PropertyName]
        {
            get
            {
                switch (PropertyName)
                {
                    default: return null;
                    case nameof(Name):
                        var name = Name;
                        if (Name is null) return "Пустая ссылка на имя";
                        if (name.Length <= 2) return "Имя должно быть длиннее двух символов";
                        if (name.Length > 20) return "Длина имени не должна быть более 20 символов";
                        return null;
                }
            }
        
        }
       

        public override string Name 
        { 
            get => base.Name; 
            set
            {
                if (value == "Иванов")
                    throw new ArgumentException("Иванов нам не подходит", nameof(value));
                base.Name = value;
            }
        }

        string IDataErrorInfo.Error => null;
    }
}
