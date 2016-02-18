using Core.Common.Contracts;

namespace PhoneBook.Business.Entities
{
    public class Phone : IIdentifiableEntity
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public int? ContactTypeId { get; set; }

        public ContactType ContactType { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }

        #region IIdentifiableEntity members
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
        #endregion
    }
}
