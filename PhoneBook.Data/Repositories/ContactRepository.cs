using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using PhoneBook.Business.Entities;
using PhoneBook.Data.Contracts.RepositoryInterfaces;

namespace PhoneBook.Data.Repositories
{
    public class ContactRepository : RepositoryBase, IContactRepository
    {
        public ContactRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public Person InsertContact(Person person)
        {
            return DbContext.Persons.Add(person);
        }

        public Person UpdateContact(Person person)
        {
            var personFromDb = GetContactById(person.Id);
            var deletedEmails = personFromDb.Emails.Where(e => person.Emails.All(p => p.Id != e.Id)).ToList();
            var deletedPhones = personFromDb.Phones.Where(e => person.Phones.All(p => p.Id != e.Id)).ToList();

            DbContext.Persons.AddOrUpdate(person);

            if (person.Emails != null)
                foreach (var email in person.Emails)
                {
                    DbContext.Emails.AddOrUpdate(email);
                }
            if (person.Phones != null)
                foreach (var phone in person.Phones)
                {
                    DbContext.Phones.AddOrUpdate(phone);
                }

            foreach (var deletedEmail in deletedEmails)
            {
                DbContext.Emails.Remove(deletedEmail);
            }
            foreach (var deletedPhone in deletedPhones)
            {
                DbContext.Phones.Remove(deletedPhone);
            }

            return person;
        }

        public void DeleteContact(int id)
        {
            var person = DbContext.Persons.Find(id);
            DbContext.Persons.Remove(person);
        }

        public List<Person> GetContacts(string filter = null)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                return DbContext.Persons.Include(p => p.Emails.Select(e => e.ContactType))
                    .Include(p => p.Phones.Select(e => e.ContactType)).ToList();
            }
            return DbContext.Persons.Where(p => p.Name.ToLower().Contains(filter) || p.Surname.ToLower().Contains(filter)
                                         || p.Emails.Any(e => e.EmailAddress.ToLower().Contains(filter))
                                         || p.Phones.Any(ph => ph.PhoneNumber.ToLower().Contains(filter)))
                                         .Include(p => p.Emails.Select(e => e.ContactType)).Include(p => p.Phones.Select(e => e.ContactType)).ToList();
        }

        public Person GetContactById(int id)
        {
            return DbContext.Persons
                .Include(p => p.Emails.Select(e => e.ContactType))
                .Include(p => p.Phones.Select(e => e.ContactType))
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
