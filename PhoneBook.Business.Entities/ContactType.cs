using Core.Common.Contracts;

namespace PhoneBook.Business.Entities
{
    public class ContactType : IIdentifiableEntity
    {
        public int Id { get; set; }

        public string Type { get; set; }

        #region IIdentifiableEntity members
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
        #endregion
    }
}
