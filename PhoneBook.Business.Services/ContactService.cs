using System.Collections.Generic;
using PhoneBook.Business.Contracts;
using PhoneBook.Business.Entities;
using PhoneBook.Data.Contracts;
using PhoneBook.Data.Contracts.RepositoryInterfaces;

namespace PhoneBook.Business.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IContactRepository contactRepository, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
        }

        public Person InsertContact(Person person)
        {
            person = _contactRepository.InsertContact(person);
            _unitOfWork.Commit();
            return person;
        }

        public Person UpdateContact(Person person)
        {
            person = _contactRepository.UpdateContact(person);
            _unitOfWork.Commit();
            return person;
        }

        public void DeleteContact(int id)
        {
            _contactRepository.DeleteContact(id);
            _unitOfWork.Commit();
        }

        public List<Person> GetContacts(string filter)
        {
            return _contactRepository.GetContacts(filter);
        }

        public Person GetContactById(int id)
        {
            return _contactRepository.GetContactById(id);
        }
    }
}
