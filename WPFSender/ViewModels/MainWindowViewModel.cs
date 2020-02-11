using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSenderLib;
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
        //private readonly IServer;
        private string title = "Рассыльщик почты";
        private ObservableCollection<Recipient> recipients;
        private ObservableCollection<Server> servers;
        private Recipient selectedRecipient;
        private Server selectedServer;

        public string Title
        { 
            get => title;
            set => Set(ref title, value);
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

        public ObservableCollection<Server> Servers
        {
            get => servers;
            set => Set(ref servers, value);
        }

        public Server SelectedServer
        {
            get => selectedServer;
            set => Set(ref selectedServer, value);
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
            recipientsManager = recipentsManager;
            Servers = new ObservableCollection<Server>();
        }
        

    }
}
