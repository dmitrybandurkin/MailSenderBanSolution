using System;
using System.Collections.Generic;
using System.Text;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using WPFSender.ViewModel;
using MailSenderLib.Services;
using MailSenderLib.Services.Interfaces;
using MailSenderLib.Services.InMemory;
using MailSenderLib.Services.Manager;
using MailSenderLib.Services.Interfaces.IManager;
using MailSenderLib.Services.Interfaces.IStore;

namespace WPFSender.ViewModels
{
    class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var services = SimpleIoc.Default;
            services.Register<MainWindowViewModel>();
            services.Register<IRecipientsManager, RecipientsManager>();//манагер работы с получателями
            services.Register<IRecipientsStore, RecipientsStoreInMemory>();//хранилище списка получателей *вп амяти
            services.Register<IServersManager, ServersManager>();//манагер с серверами
            services.Register<IServersStore, ServersStoreInMemory>();//хранилище серверов *в памяти
            services.Register<ISendersManager, SendersManager>();//манагер отправителей
            services.Register<ISendersStore, SendersStoreInMemory>();//хранилице списка отправителей *в памяти
            services.Register<IMessageSender, MessageSenderManager>();//манагер отправки сообщений
            services.Register<IMailStore, MailsStoreInMemory>();//хранилище списка писем *в памяти
            services.Register<IMailListManager, MailListManager>();//манагер работы с письмами


        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
