using System.Web.Mvc;
namespace StudentRegistrationSystem.Controllers
{
    public class UserPanelController : Controller
    {     
        public ActionResult Index()
        {
            return View();
        }
    }
}