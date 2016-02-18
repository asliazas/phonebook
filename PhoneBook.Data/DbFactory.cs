using Core.Common.Core;

namespace PhoneBook.Data
{
    public class DbFactory : Disposable
    {
        PhoneBookDbContext dbContext;

        public PhoneBookDbContext Init()
        {
            return dbContext ?? (dbContext = new PhoneBookDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
