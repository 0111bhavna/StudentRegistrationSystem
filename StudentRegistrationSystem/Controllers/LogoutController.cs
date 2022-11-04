using System.Web.Mvc;
namespace StudentRegistrationSystem.Controllers
{
    public class LogoutController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOff()
        {
            return RedirectToAction("Login", "Login");
        }
    }
}