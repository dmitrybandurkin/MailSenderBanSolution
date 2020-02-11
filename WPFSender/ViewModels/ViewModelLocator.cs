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

namespace WPFSender.ViewModels
{
    class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var services = SimpleIoc.Default;
            ServiceLocator.SetLocatorProvider(() => services);
            services.Register<MainWindowViewModel>();
            services.Register<IRecipientsManager,RecipientsManager>();
            services.Register<IRecipientsStore,RecipientsStoreInMemory>();
            services.Register<IServerManager, ServerManager>();
            services.Register<IServerStore, ServersStoreInMemory>();
        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
