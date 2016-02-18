namespace PhoneBook.Client.Web.Models
{
    public class Email
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string ContactTypeId { get; set; }

        public int PersonId { get; set; }

        public ContactType ContactType { get; set; }
    }
}