using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MailSenderLib.Models.Base;

namespace MailSenderLib.Models
{
    public class MailingList:NamedEntity
    {
        public IEnumerable<Recipient> Recipients { get; set; } = new ObservableCollection<Recipient>();
    }
}
