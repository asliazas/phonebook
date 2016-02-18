using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using PhoneBook.Business.Bootstrapper;
using PhoneBook.Data;
using SimpleInjector.Integration.WebApi;

namespace PhoneBook.Client.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // var container = SimpleInjectorBootstrapper.MvcInit();
            var apiContainer = SimpleInjectorBootstrapper.WebApiInit();
            //   DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(apiContainer);
            AutoMapperConfig.RegisterMappings();

            Database.SetInitializer(new DbInitializer());
        }

        public static MapperConfiguration MapperConfiguration { get; set; }
        public static IMapper Mapper { get; set; }
    }
}
