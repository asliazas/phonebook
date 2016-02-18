namespace PhoneBook.Data.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
