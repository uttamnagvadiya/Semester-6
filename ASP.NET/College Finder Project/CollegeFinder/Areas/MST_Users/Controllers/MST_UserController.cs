using CollegeFinder.Areas.MST_Users.Models;
using CollegeFinder.BAL.MST_User;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.RegularExpressions;

namespace CollegeFinder.Areas.MST_Users.Controllers
{
    [Area("MST_Users")]
    public class MST_UserController : Controller
    {
        MST_Users_BAL user_BAL = new MST_Users_BAL();
        public IActionResult Index()
        {
            return View("SignIn");
        }
        
        public IActionResult SignUp()
        {
            return View();
        }

        #region Set Session Fields ...
        public void SetSessionFields(DataTable dt)
        {
            foreach (DataRow dataRow in dt.Rows)
            {
                HttpContext.Session.SetString("UserID", dataRow["UserID"].ToString());
                HttpContext.Session.SetString("Username", dataRow["Username"].ToString());
                HttpContext.Session.SetString("Email", dataRow["Email"].ToString());
                HttpContext.Session.SetString("IsAdmin", dataRow["IsAdmin"].ToString());
                HttpContext.Session.SetString("IsActive", dataRow["IsActive"].ToString());
                break;
            }
        }
        #endregion

        #region User Login ...
        [HttpPost]
        public IActionResult UserLogin(MST_UserLoginModel userLoginModel)
        {
            /*if (userLoginModel.Username == null)
            {
                TempData["UsernameError"] = "Username field is required.";
            }
            if (userLoginModel.Password == null)
            {
                TempData["PasswordError"] = "Password field is required";
                return RedirectToAction("Index");
            }*/
            
            if (ModelState.IsValid)
            {
                DataTable dataTable = user_BAL.PR_LOGIN_SELECT_RECORD_BY_USERNAME_PASSWORD(Username: userLoginModel.Username.ToString(), Password: userLoginModel.Password.ToString());
                if (dataTable.Rows.Count > 0)
                {
                    SetSessionFields(dataTable);
                }
                else
                {
                    TempData["ErrorMessage"] = "Incorrect Username or Password.";
                    return RedirectToAction("Index");
                }

                if (HttpContext.Session.GetString("UserID") != null)
                {
                    return Convert.ToBoolean(HttpContext.Session.GetString("IsAdmin").ToString())
                        ? RedirectToAction("Index", "MST_Admin", new { area = "MST_Admin" })
                        : RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region User Register ...
        public IActionResult Register(MST_UserModel userModel)
        {
            TempData["PasswordRegexPatternError"] = TempData["ConfirmPasswordMatchError"] = TempData["InvalidDetailsError"] = "";
            string PasswordRegexPattern = "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[!@#$%^&*()_+])[A-Za-z\\d!@#$%^&*()_+]{8,}$";

            if (ModelState.IsValid)
            {
                if (!Regex.IsMatch(userModel.ConfirmPassword, PasswordRegexPattern))
                {
                    TempData["PasswordRegexPatternError"] = "Password must be at least 8 characters long and contain at letters, digits, and special symbols.";
                }
                else
                {
                    if (!userModel.Password.ToString().Equals(userModel.ConfirmPassword.ToString()))
                    {
                        TempData["ConfirmPasswordMatchError"] = "The password and confirm password fields do not match. Please ensure both fields contain the same password.";
                    }
                    else
                    {
                        bool isInsertedSuccessfull = user_BAL.PR_REGISTER_INSERT_RECORD(userModel);
                        if (isInsertedSuccessfull)
                        {
                            DataTable dataTable = user_BAL.PR_LOGIN_SELECT_RECORD_BY_USERNAME_PASSWORD(Username: userModel.Username.ToString(), Password: userModel.ConfirmPassword.ToString());
                            if (dataTable.Rows.Count > 0)
                            {
                                SetSessionFields(dataTable);
                            }
                            return RedirectToAction("Index", "Home", new { area = "" });
                        }
                        else
                        {
                            TempData["InvalidDetailsError"] = "Please, Try again!";
                        }
                    }
                }

            }
            return RedirectToAction("SignUp");
        }
        #endregion

        #region User Logout ...
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home", new {area = ""});
        }
        #endregion

    }
}
