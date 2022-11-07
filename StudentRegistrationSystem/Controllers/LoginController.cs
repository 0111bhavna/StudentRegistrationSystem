using RepositoryLibrary.Models;
using ServiceLibrary.Business_Logic;
using System;
using System.Web;
using System.Web.Mvc;
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

        [HttpPost]
        public ActionResult LogOff()
        {
            this.Session.Clear();
            this.Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}
