using MailSenderLib.Models.Base;
using System;

namespace MailSenderLib.Models
{
    /// <summary>
    /// задача планировщика
    /// </summary>
    public class SchedulerTask:BaseEntity
    {
        /// <summary>
        /// время выполнения задания
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// отправитель почты
        /// </summary>
        public Sender Sender { get; set; }
        /// <summary>
        /// список получателей
        /// </summary>
        public MailingList Recipients { get; set; }
        /// <summary>
        /// сервер, через который осуществляется отправка почты
        /// </summary>
        public Server Server { get; set; }
        /// <summary>
        /// отправляемое письмо
        /// </summary>
        public Mail Mail { get; set; }
    }
}
