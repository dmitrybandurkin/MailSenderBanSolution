using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSenderLib.Models;
using MailSenderLib.Services;
using MailSenderLib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace WPFSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRecipientsManager recipientsManager;
        private static string title;
        private static ObservableCollection<Recipient> recipients;
        private Recipient selectedRecipient;

        public string Title
        { 
            get => title;
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

        public Recipient SelectedRecipient
        {
            get => selectedRecipient;
            set => Set(ref selectedRecipient, value);
        }
        public ICommand LoadRecipientDataCommand { get; }
        private bool CanLoadRecipientsDataCommandExecute() => true;
        private void OnLoadRecipientDataCommandExecuted()
        {
            Recipients = new ObservableCollection<Recipient>(recipientsManager.GetAll());
        }
        public ICommand SaveRecipientChangesCommand { get; }
        private bool CanSaveRecipientChangesCommandExecute(Recipient recipient) => recipient != null;
        private void OnSaveRecipientChangesCommandExecuted(Recipient recipient)
        {
            recipientsManager.Edit(recipient);
            recipientsManager.SaveChanges();
        }

        public ICommand DeleteRecipientDataCommand { get; }

        private bool CanDeleteRecipientDataCommand(Recipient recipient) => recipient != null;

        private void OnDeleteRecipientDataCommand(Recipient recipient)
        {
            recipientsManager.Remove(recipient.Id);
            Recipients = new ObservableCollection<Recipient>(recipientsManager.GetAll()); //строка для теста
        }

        public  MainWindowViewModel(IRecipientsManager recipentsManager)
        {
            LoadRecipientDataCommand = new RelayCommand(OnLoadRecipientDataCommandExecuted, CanLoadRecipientsDataCommandExecute);
            SaveRecipientChangesCommand = new RelayCommand<Recipient>(OnSaveRecipientChangesCommandExecuted, CanSaveRecipientChangesCommandExecute);
            DeleteRecipientDataCommand = new RelayCommand<Recipient>(OnDeleteRecipientDataCommand, CanDeleteRecipientDataCommand);
            this.recipientsManager = recipentsManager;
        }
        

    }
}
