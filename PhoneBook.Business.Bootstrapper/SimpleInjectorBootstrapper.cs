using PhoneBook.Business.Contracts;
using PhoneBook.Business.Services;
using PhoneBook.Data;
using PhoneBook.Data.Contracts;
using PhoneBook.Data.Contracts.RepositoryInterfaces;
using PhoneBook.Data.Repositories;
using SimpleInjector;

namespace PhoneBook.Business.Bootstrapper
{
    public static class SimpleInjectorBootstrapper
    {
        public static Container WebApiInit()
        {
            var container = new Container();

            container.RegisterWebApiRequest<IUnitOfWork, UnitOfWork>();

            container.RegisterWebApiRequest<IContactRepository, ContactRepository>();

            container.RegisterWebApiRequest<IContactService, ContactService>();

            container.RegisterWebApiRequest<DbFactory, DbFactory>();

            return container;
        }
    }
}
