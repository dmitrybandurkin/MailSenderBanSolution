namespace MailSenderLib.Models.Base
{
    public abstract class NamedEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
