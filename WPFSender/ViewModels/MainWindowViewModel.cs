using GalaSoft.MvvmLight;
using MailSenderLib.Models;
using MailSenderLib.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WPFSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly RecipentsManager recipentsManager;
        private static string title;
        private static ObservableCollection<Recipient> recipients;

        public string Title
        { get => title;
            set => Set(ref title, value);
        }

        static MainWindowViewModel()
        {
            title = "Рассыльщик почты";
        }


        public ObservableCollection<Recipient> Recipients
        {
            get => recipients;
            private set => Set(ref recipients, value);
        }
        public  MainWindowViewModel(RecipentsManager recipentsManager)
        {
            this.recipentsManager = recipentsManager;
            recipients = new ObservableCollection<Recipient>(recipentsManager.GetAll());
        }
    }
}
