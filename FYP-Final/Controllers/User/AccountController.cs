using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using FYP1.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace FYP1.Controllers
{
    public class AccountController : Controller
    {
        private const string LOGIN_SQL =
        //@"SELECT * FROM Account WHERE UserName = '{0}' AND User_PW = HASHBYTES('SHA1', '{1}')";
        @"SELECT * FROM AppUser WHERE UserName = '{0}' AND User_PW = HASHBYTES('SHA1', '{1}')";

        //private const string LASTLOGIN_SQL = @"UPDATE Account SET SysUser=GETDATE() WHERE UserID={0}";
        //private const string LASTLOGIN_SQL = @"UPDATE AppUser SET AppUser=GETDATE() WHERE UserName='{0}'";

        private const string ROLE_COL = "CompanyType";
        private const string NAME_COL = "UserName";

        private const string REDIRECT_CNTR = "Home";
        private const string REDIRECT_ACTN = "Index";

        private const string LOGIN_VIEW = "Login";

        [AllowAnonymous]
        public IActionResult Forbidden()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            TempData["returnUrl"] = returnUrl;
            return View(LOGIN_VIEW);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (!AuthenticateUser(login.UserName, login.Password, out ClaimsPrincipal principal))
            {
                ViewData["Message"] = "Incorrect User Name or Password";
                ViewData["MsgType"] = "warning";
                return View(LOGIN_VIEW);
            }

            else
            {
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    IsPersistent = login.RememberMe
                });

                //DBUtl.ExecSQL(LASTLOGIN_SQL, login.UserName);

                if (TempData["returnUrl"] != null)
                {
                    string returnUrl = TempData["returnUrl"].ToString();
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                }
                return RedirectToAction("Index", "Home");
            }

        }

        [Authorize]
        public IActionResult Logoff(string returnUrl = null)
        {
            HttpContext.SignOutAsync
                (CookieAuthenticationDefaults.AuthenticationScheme);
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction(REDIRECT_ACTN, REDIRECT_CNTR);
        }

        [AllowAnonymous]

        public IActionResult VerifyUserName(String UserName)
        {
            string select = $"SELECT * FROM Account WHERE UserName='{UserName}'";

            if (DBUtl.GetTable(select).Rows.Count > 0)
            {
                return Json($"[{UserName}] already in use");
            }
            return Json(true);
        }

        private bool AuthenticateUser(string uid, string pw, out ClaimsPrincipal principal)
        {
            principal = null;
     
            DataTable ds = DBUtl.GetTable(LOGIN_SQL, uid, pw);
            if (ds.Rows.Count == 1)
            {
                string r = "";
                int ro = int.Parse(ds.Rows[0][ROLE_COL].ToString());
                if (ro == 1)
                    r = "Admin";
                else if (ro == 2)
                    r = "Current";
                else if (ro == 3)
                    r = "Alumni";

                principal = new ClaimsPrincipal(
                    new ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, uid),
                            new Claim(ClaimTypes.Name, ds.Rows[0] [NAME_COL].ToString()),
                            new Claim(ClaimTypes.Role, r)
                        }, "Basic"
                )
            );
                return true;
            }
            return false;
        }

        [AllowAnonymous]
        public IActionResult ResetPW()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ResetPW(ResetPW reset)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Invalid Input";
                ViewData["MsgType"] = "warning";
                return View("ResetPW");
            }

            else
            {
                string UserName = reset.UserName.ToString();
                string password = reset.User_PW_New.ToString();
                string cfmpassword = reset.ConfirmPasswordNew.ToString();
                //string sql = @"SELECT * FROM Account WHERE UserName='{0}'";
                string sql = @"SELECT * FROM AppUser WHERE UserName='{0}'";
                Console.WriteLine(sql);
                string select = String.Format(sql,UserName);
                Console.WriteLine("select");
                DataTable dt = DBUtl.GetTable(select);

                if (password.Equals(cfmpassword))
                {
                    //string update = @"UPDATE Account SET User_PW = HASHBYTES('SHA1','{1}') WHERE UserName = '{0}'";
                    string update = @"UPDATE AppUser SET User_PW = HASHBYTES('SHA1','{1}') WHERE UserName = '{0}'";
                    Console.WriteLine(update);
                    int res = DBUtl.ExecSQL(update, UserName, password);
                    Console.WriteLine(res);
                    if (res == 1)
                    {
                        ViewData["Message"] = "Password has been reset successfully!";
                        ViewData["MsgType"] = "success";
                        return View("ResetPWActivate");
                    }
                    else
                    {
                        ViewData["Message"] = "Password reset unsuccessful.";
                        ViewData["MsgType"] = "warning";
                        return View("ResetPW");
                    }
                }
                else
                {
                    ViewData["Message"] = "Username cannot be verified.";
                    ViewData["MsgType"] = "danger";
                }

                return View("ResetPWActivate");
            }
        }


        [AllowAnonymous]
        public IActionResult ResetPWEmail()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ResetPWEmail(ResetPWEmail Reset)
        {
            var output = VerifyEmail(Reset.Email);
            if (output == true)
            {
                return View("ResetPW");
            }
            else
                ViewData["Message"] = "No such email exists.";
                ViewData["MsgType"] = "warning";
                return View("ResetPWEmail");
        }

        [AllowAnonymous]
        public IActionResult ResetPWConfirm()
        {
            return View();
        }

        [AllowAnonymous]
        public bool VerifyEmail(String Email)
        {
            //string select = @"SELECT * FROM Account WHERE Email='{0}'";
            string select = @"SELECT * FROM AppUser WHERE Email='{0}'";
            DataTable ds = DBUtl.GetTable(select, Email);

            if (ds.Rows.Count == 1)
            {
                return true;
            }
            return false;
        }
    }
}