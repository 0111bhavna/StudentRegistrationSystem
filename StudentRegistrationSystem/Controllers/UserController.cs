using System.Web.Mvc;
namespace UniversityRegistration.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}