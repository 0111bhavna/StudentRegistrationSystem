using ServiceLibrary.Business_Logic;
using System.Web.Mvc;
namespace StudentRegistrationSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentBL studentBL;
        public StudentController(IStudentBL studentBL)
        {
            this.studentBL = studentBL;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult isNidValid(string nationalId)
        {
            var response = studentBL.DoesNidExist(nationalId);
            return Json(new { result = response});
        }
        public JsonResult isPhoneNumberValid(string phoneNumber)
        {
            var response = studentBL.DoesPhoneNumberExist(phoneNumber);
            return Json(new { result = response});
        }
    }
}