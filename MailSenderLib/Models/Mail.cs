using MailSenderLib.Models.Base;

namespace MailSenderLib.Models
{
    public class Mail:BaseEntity
    {
        public string Subject { get; set; }
        public string Body { get; set; }

        //сюда же можно коллекции вложений вписать
    }
}
