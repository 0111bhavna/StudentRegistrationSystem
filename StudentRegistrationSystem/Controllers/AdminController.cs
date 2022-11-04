using System.Web.Mvc;
namespace StudentRegistrationSystem.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewSummary()
        {
            return View();
        }
    }
}