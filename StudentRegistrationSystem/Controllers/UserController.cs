using ServiceLibrary.Business_Logic;
using System.Web.Mvc;
namespace UniversityRegistration.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult isEmailValid(string email)
        {
            var response = userBL.DoesEmailExist(email);
            return Json(new { result = response });
        }
    }
}