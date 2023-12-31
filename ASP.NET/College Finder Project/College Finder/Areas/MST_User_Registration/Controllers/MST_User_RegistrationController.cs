using College_Finder.Areas.MST_User_Registration.Models;
using College_Finder.BAL;
using College_Finder.BAL.MST_User_Registration;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace College_Finder.Areas.MST_User_Registration.Controllers
{
    [Area("MST_User_Registration")]
    public class MST_User_RegistrationController : Controller
    {
        MST_User_Registration_BAL user_BAL = new MST_User_Registration_BAL();
        public IActionResult Index()
        {
            return View("Login_Register");
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(MST_User_LoginModel userLoginModel)
        {
            if (userLoginModel.Username == null)
            {
                TempData["UsernameError"] = "Username field is required.";
            }
            if (userLoginModel.Password == null)
            {
                TempData["PasswordError"] = "Password field is required";
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                DataTable dataTable = user_BAL.PR_LOGIN_SELECT_RECORD_BY_USERNAME_PASSWORD(userLoginModel);
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        HttpContext.Session.SetString("UserID", dataRow["UserID"].ToString());
                        HttpContext.Session.SetString("Username", dataRow["Username"].ToString());
                        HttpContext.Session.SetString("Email", dataRow["Email"].ToString());
                        HttpContext.Session.SetString("Password", dataRow["Password"].ToString());
                        HttpContext.Session.SetString("IsAdmin", dataRow["IsAdmin"].ToString());
                        HttpContext.Session.SetString("IsActive", dataRow["IsActive"].ToString());
                        break;
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Incorrect Username or Password.";
                    return RedirectToAction("Index");
                }

                if (HttpContext.Session.GetString("Username") != null && HttpContext.Session.GetString("Password") != null)
                {
                    return Convert.ToBoolean(HttpContext.Session.GetString("IsAdmin").ToString())
                        ? RedirectToAction("Index", "MST_Admin", new {area = "MST_Admin"})  // Change to RedirectToAction()
                        : RedirectToAction("Index", "Home", new { area = "" });     // Change to RedirectToAction()
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
