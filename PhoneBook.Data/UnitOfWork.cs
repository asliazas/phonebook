using PhoneBook.Data.Contracts;

namespace PhoneBook.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbFactory _dbFactory;
        private PhoneBookDbContext _context;

        public UnitOfWork(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public PhoneBookDbContext DbContext
        {
            get { return _context ?? (_context = _dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
