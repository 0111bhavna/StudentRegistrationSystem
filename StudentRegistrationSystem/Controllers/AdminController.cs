using RepositoryLibrary.Models;
using ServiceLibrary.Business_Logic;
using System.Web.Mvc;
namespace StudentRegistrationSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IStudentBL StudentBL;
            public AdminController(IStudentBL studentBL)
            {
               StudentBL = studentBL;
            }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewSummary()
        {
            return View();
        }
      
        public JsonResult AssignStatus()
        {

            var response = StudentBL.GetSortedStudentsByPoints();
         
            return Json(response,JsonRequestBehavior.AllowGet);
        }
        
    }
}