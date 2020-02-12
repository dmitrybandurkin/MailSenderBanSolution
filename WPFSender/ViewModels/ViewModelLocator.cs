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
            services.Register<IRecipientsManager, RecipientsManager>();
            services.Register<IRecipientsStore, RecipientsStoreInMemory>();
            services.Register<IServersManager, ServersManager>();
            services.Register<IServersStore, ServersStoreInMemory>();
            services.Register<ISendersManager, SendersManager>();
            services.Register<ISendersStore, SendersStoreInMemory>();

        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
