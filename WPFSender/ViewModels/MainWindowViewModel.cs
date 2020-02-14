using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSenderLib;
using MailSenderLib.Models;
using MailSenderLib.Services;
using MailSenderLib.Services.Interfaces;
using MailSenderLib.Services.Interfaces.IManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Security;
using System.Diagnostics;

namespace WPFSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRecipientsManager recipientsManager;
        private readonly IServersManager serversManager;
        private readonly ISendersManager sendersManager;
        private readonly IMessageSender messageSenderManager;
        private readonly IMailListManager mailListManager;

        private string title = "Рассыльщик почты";

        private ObservableCollection<Recipient> recipients;
        private ObservableCollection<Server> servers;
        private ObservableCollection<Sender> senders;
        private ObservableCollection<Mail> mails;

        private Recipient selectedRecipient;
        private Server selectedServer;
        private Sender selectedSender;
        private Mail selectedMail;

        private SecureString password;//передать через интерфейс

        private string mailSubject;//через интерфейс
        private string mailBody;//через интерфейс

        public string MailSubject
        {
            get => mailSubject;
            set => Set(ref mailSubject, value);
        }

        public string MailBody
        {
            get => mailBody;
            set => Set(ref mailBody, value);
        }

        public string Title
        { 
            get => title;
            set => Set(ref title, value);
        }

        public SecureString Password
        {
            get => password;
            set => Set(ref password, value);
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

        public ObservableCollection<Sender> Senders
        {
            get => senders;
            set => Set(ref senders, value);
        }

        public Sender SelectedSender
        {
            get => selectedSender;
            set => Set(ref selectedSender, value);
        }

        public ObservableCollection<Mail> Mails
        {
            get => mails;
            set => Set(ref mails, value);
        }

        public Mail SelectedMail
        {
            get => selectedMail;
            set => Set(ref selectedMail, value);
        }



        #region команды управления кнопок окна получателей
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
        #endregion

        #region создание письма
        public ICommand CreateMailCommand { get; }
        private bool CanCreateMailCommandExecute() => true;
        private void OnCreateMailCommandExecuted()
        {
            mailListManager.Add(new Mail() { Subject = MailSubject, Body = MailBody, Id = 1 });
            Mails = new ObservableCollection<Mail>(mailListManager.GetAll());
        }
        #endregion

        #region кнопка отправки сообщения
        public ICommand SendMessageCommand { get; }
        private bool CanSendMessageCommand() => true;
        private void OnSendMessageCommandExecuted()
        {
            if ((SelectedServer != null) && (SelectedRecipient != null) && (SelectedSender != null))
                messageSenderManager.SendEMail(SelectedSender.Address, SelectedRecipient.Address, "Subject", "Body", SelectedServer.Port, SelectedServer.Address, SelectedServer.Login, Password);
        } 
        #endregion
        public MainWindowViewModel(
            IRecipientsManager RecipientsManager, IServersManager ServersManager, 
            ISendersManager SendersManager,IMessageSender MessageSenderManager,
            IMailListManager MailListManager)
        {
            LoadRecipientDataCommand = new RelayCommand(OnLoadRecipientDataCommandExecuted, CanLoadRecipientsDataCommandExecute);
            SaveRecipientChangesCommand = new RelayCommand<Recipient>(OnSaveRecipientChangesCommandExecuted, CanSaveRecipientChangesCommandExecute);
            DeleteRecipientDataCommand = new RelayCommand<Recipient>(OnDeleteRecipientDataCommand, CanDeleteRecipientDataCommand);
            SendMessageCommand = new RelayCommand(OnSendMessageCommandExecuted, CanSendMessageCommand);
            CreateMailCommand = new RelayCommand(OnCreateMailCommandExecuted, CanCreateMailCommandExecute);
            
            recipientsManager = RecipientsManager;
            serversManager = ServersManager;
            sendersManager = SendersManager;
            messageSenderManager = MessageSenderManager;
            mailListManager = MailListManager;
            
            Servers = new ObservableCollection<Server>(serversManager.GetAll());
            Senders = new ObservableCollection<Sender>(sendersManager.GetAll());
            Mails = new ObservableCollection<Mail>(mailListManager.GetAll());
        }
        

    }
}
