namespace PhoneBook.Data
{
    public abstract class RepositoryBase
    {
        private PhoneBookDbContext _dataContext;

        protected DbFactory DbFactory
        {
            get;
            private set;
        }

        protected PhoneBookDbContext DbContext
        {
            get
            {
                return _dataContext ?? (_dataContext = DbFactory.Init());
            }
        }

        protected RepositoryBase(DbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }
    }
}
