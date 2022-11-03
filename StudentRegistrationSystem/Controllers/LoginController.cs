using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Reflection;
using ServiceLibrary.Business_Logic;
using RepositoryLibrary.Models;
using System.Security.Policy;


namespace StudentRegistrationSystem.Controllers
{
    public class LoginController : Controller
        
    {

        /*
        string connectionstring = @"Data Source=L-PW02X092\SQLEXPRESS;Initial Catalog=""StudentRegistration SystemDb"";Integrated Security=True";
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Authenticate(User user)
        {
            //user.email = "bhavnaoochit@gmail.com";
            bool IsUserValid = false;
            using(SqlConnection sqlcon= new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                string query = "select Email, Password from Users where Email=@email";
                SqlCommand cmd=new SqlCommand(query,sqlcon);
                cmd.Parameters.AddWithValue("@email",user.email);
                SqlDataReader sdr=cmd.ExecuteReader();

                IsUserValid = false;
                 if (sdr.Read())
                {
                    DataTable table = new DataTable();

                    //IsUserValid =BCrypt.Net.BCrypt.Verify(user.password);
                    ViewData["message"] = "user logged in successfully";
                }
                else
                {
                    ViewData["message"] = "not logged in";
                }
                sqlcon.Close();
            }
            return Json(new { result = IsUserValid, url = Url.Action("Index", "User") });*/

        private readonly IUserBL UserBL;

        public LoginController(IUserBL userBL)
        {
            UserBL = userBL;
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Authentication(LoginModel _loginModel)
        {
            var IsUserValid = false;
            string _url = "";
            IsUserValid = UserBL.AuthenticateUser(_loginModel);
            if (IsUserValid)
            {
                _url = Url.Action("HomePage", "Index");
            }

            return Json(new
            {
                result = IsUserValid,
                url = _url
            });

        }
    }


}
