using RepositoryLibrary.Models;
using ServiceLibrary.Business_Logic;
using System.Collections.Generic;
using System.Web.Mvc;
namespace StudentRegistrationSystem.Controllers
{
    public class ApplicationController : Controller
    {
        private int? UserId = null;
        private readonly IStudentBL StudentBL;
        public ApplicationController(IStudentBL studentBL)
        {
            StudentBL = studentBL;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddStudentResult(List<Result> ResultList)
        {
            int? userId = SessionHandler.GetUserIdFromSession();
            bool success=StudentBL.AddStudentResult(ResultList, (int)userId);
            return Json(success);
        }
    }    
}