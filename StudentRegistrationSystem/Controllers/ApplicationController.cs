using RepositoryLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers
{
    public class ApplicationController : Controller
    {
        private int? UserId = null;
        public ApplicationController()
        {
            //  if (Session[""])
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddStudentResult(List<Result> resultList)
        {
            return Json(resultList);
        }
    }    
}