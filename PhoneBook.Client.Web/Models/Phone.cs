namespace PhoneBook.Client.Web.Models
{
    public class Phone
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public string ContactTypeId { get; set; }

        public int PersonId { get; set; }

        public ContactType ContactType { get; set; }
    }
}