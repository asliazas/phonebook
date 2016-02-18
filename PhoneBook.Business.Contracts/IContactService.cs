using System.Collections.Generic;
using PhoneBook.Business.Entities;

namespace PhoneBook.Business.Contracts
{
    public interface IContactService
    {
        Person InsertContact(Person person);

        Person UpdateContact(Person person);

        void DeleteContact(int id);

        List<Person> GetContacts(string filter);

        Person GetContactById(int id);
    }
}
