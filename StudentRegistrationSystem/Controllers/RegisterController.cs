using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using ServiceLibrary.Business_Logic;
using RepositoryLibrary.Models;

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