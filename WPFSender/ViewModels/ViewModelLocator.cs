﻿using System;
using System.Collections.Generic;
using System.Text;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using WPFSender.ViewModel;
using MailSenderLib.Services;
using MailSenderLib.Services.Interfaces;

namespace WPFSender.ViewModels
{
    class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var services = SimpleIoc.Default;
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            services.Register<MainWindowViewModel>();
            services.Register<RecipientsManager>();
            services.Register<RecipientsStoreInMemory>();
        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
