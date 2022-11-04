using RepositoryLibrary.Models;
using ServiceLibrary.Business_Logic;
using System.CodeDom;
using System.Web;
using System.Web.Mvc;
using System;
namespace StudentRegistrationSystem.Controllers
{
    public static class SessionHandler
    {
        public static int? GetUserIdFromSession()
        {
            int? userId = null;
            if (HttpContext.Current.Session["UserId"]!=null)
            {
                userId = (int)HttpContext.Current.Session["UserId"];
            }
            return userId;
        }
        public static Role? GetRoleFromSession()
        {
            Role? role = null;
            if (HttpContext.Current.Session["Role"] != null)
            {
                string strRole = HttpContext.Current.Session["Role"].ToString();
                role=(Role)Enum.Parse(typeof(Role), strRole);
            }
            return role;
        }
    }
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
                Role role = (Role)SessionHandler.GetRoleFromSession();
                if (role.Equals(Role.Admin))
                    _url = Url.Action("Index", "Admin");
                else
                {
                    _url = Url.Action("Index", "HomePage");
                }
            }
            return Json(new
            {
                result = IsUserValid,
                url = _url
            });
        }
        public ActionResult LogOff()
        {
            return RedirectToAction("Login", "Login");
        }
    }
}
