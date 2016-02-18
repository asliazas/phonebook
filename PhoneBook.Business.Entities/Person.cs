using System.Collections.Generic;
using Core.Common.Contracts;

namespace PhoneBook.Business.Entities
{
    public class Person : IIdentifiableEntity
    {
        public Person()
        {
            Emails = new HashSet<Email>();
            Phones = new HashSet<Phone>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public ICollection<Email> Emails { get; set; }

        public ICollection<Phone> Phones { get; set; }

        #region IIdentifiableEntity members
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
        #endregion
    }
}
