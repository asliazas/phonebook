using System.Data.Entity;
using PhoneBook.Data;

namespace PhoneBook.Client.Web
{
    internal class DbInitializer : MigrateDatabaseToLatestVersion<PhoneBookDbContext, Data.Migrations.Configuration>
    {
    }
}