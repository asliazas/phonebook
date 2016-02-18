using System.Web.Mvc;

namespace PhoneBook.Client.Web.Controllers.MVC
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}