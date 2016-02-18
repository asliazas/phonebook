using System.Collections.Generic;
using PhoneBook.Business.Entities;

namespace PhoneBook.Data.Contracts.RepositoryInterfaces
{
    public interface IContactRepository
    {
        Person InsertContact(Person person);

        Person UpdateContact(Person person);

        void DeleteContact(int id);

        List<Person> GetContacts(string filter);

        Person GetContactById(int id);
    }
}
