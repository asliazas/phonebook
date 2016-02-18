using AutoMapper;
using PhoneBook.Business.Entities;

namespace PhoneBook.Client.Web
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            MvcApplication.MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Person, Models.Contact>().ReverseMap();
                cfg.CreateMap<ContactType, Models.ContactType>().ReverseMap();
                cfg.CreateMap<Email, Models.Email>().ReverseMap();
                cfg.CreateMap<Phone, Models.Phone>().ReverseMap();
            });

            MvcApplication.Mapper = MvcApplication.MapperConfiguration.CreateMapper();

            //Mapper.CreateMap<Person, Models.Contact>().ReverseMap();
            //Mapper.CreateMap<ContactType, Models.ContactType>().ReverseMap();
            //Mapper.CreateMap<Email, Models.Email>().ReverseMap();
            //Mapper.CreateMap<Phone, Models.Phone>().ReverseMap();
        }
    }
}
