using PhoneBook.Business.Entities;

namespace PhoneBook.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<PhoneBookDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhoneBookDbContext context)
        {
            context.ContactTypes.AddOrUpdate(
                new ContactType { Type = "Mobile" },
                new ContactType { Type = "Business" },
                new ContactType { Type = "Home"},
                new ContactType { Type = "Personal" });
        }
    }
}
