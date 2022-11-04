using RepositoryLibrary.Models;
using ServiceLibrary.Business_Logic;
using System.Web.Mvc;
namespace StudentRegistrationSystem.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IStudentBL StudentBL;
        public RegisterController(IStudentBL studentBL)
        {
            StudentBL= studentBL;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ResultDetails()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CreateStudent(User user)
        {
            var response = StudentBL.CreateStudent(user);
            return Json(new { result = response });
        }
    }
}