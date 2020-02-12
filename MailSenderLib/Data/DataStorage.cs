using MailSenderLib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MailSenderLib.Data
{
    public static class DataStorage
    {

        public static ObservableCollection<Sender> Senders;
        public static ObservableCollection<Server> Servers;
        public static ObservableCollection<Recipient> Recipients;

        static DataStorage()
        {
            Senders = new ObservableCollection<Sender>()
            {
                new Sender("Дмитрий 1", "dmitrybandurkin@gmail.com"),
                new Sender("Дмитрий 2", "dmitryvb@mail.ru")
            };

            Servers = new ObservableCollection<Server>()
            {
                new Server("GMail","smtp.gmail.com",587,"dmitrybandurkin@gmail.com","password"),
                new Server("Mail","smtp.mail.ru",587,"dmitryvb@mail.ru","password")
            };

            Recipients = new ObservableCollection<Recipient>()
            {
                new Recipient(1, "Дмитрий 3","dmitrybandurkin@gmail.com"),
                new Recipient(2, "Дмитрий 4","dmitryvb@mail.com")
            };
        }
    }
}
