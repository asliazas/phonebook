using System.Collections.Generic;

namespace PhoneBook.Client.Web.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }


        public List<Email> Emails { get; set; }

        public List<Phone> Phones { get; set; }
    }
}