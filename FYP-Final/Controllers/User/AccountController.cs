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
        @"SELECT * FROM AppUser WHERE UserName = '{0}' AND User_PW = HASHBYTES('SHA1', '{1}')";

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

            //If email is confirmed
            var dsconfirm = new DataTable();
            string sql = $"SELECT Email FROM AppUser WHERE UserName = '{uid}' AND User_PW = HASHBYTES('SHA1','{pw}') ";
            DataTable dsemail = DBUtl.GetTable(sql, uid, pw);
            if (dsemail.Rows.Count > 0)
            {
                string select = $"SELECT * FROM Email WHERE Email = '{dsemail.Rows[0]["Email"]}'";
                dsconfirm = DBUtl.GetTable(select);
            }

            DataTable ds = DBUtl.GetTable(LOGIN_SQL, uid, pw);
            if (ds.Rows.Count == 1)
            {
                var a = dsconfirm.Rows[0]["EmailStatus"].ToString();
                if (a.Equals("1"))
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
            }
            return false;
        }


        [AllowAnonymous]
        public IActionResult ResetPW(string un)
        {
            TempData["un"] = un;
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
                //string UserName = reset.UserName.ToString();
                string UserName = TempData["un"].ToString();
                string password = reset.User_PW_New.ToString();
                string cfmpassword = reset.ConfirmPasswordNew.ToString();

                string sql = @"SELECT * FROM AppUser WHERE UserName='{0}'";
                string select = String.Format(sql, UserName);
                DataTable dt = DBUtl.GetTable(select);

                if (password.Equals(cfmpassword))
                {
                    string update = @"UPDATE AppUser SET User_PW = HASHBYTES('SHA1','{1}') WHERE UserName = '{0}'";
                    int res = DBUtl.ExecSQL(update, UserName, password);
                    if (res == 1)
                    {
                        ViewData["Message"] = "Password reset successful!";
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

                return View("ResetPW");
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
                string email = Reset.Email.ToString();
                string select = "SELECT * FROM AppUser WHERE Email='{0}'";
                DataTable dt = DBUtl.GetTable(select, email);

                foreach (DataRow row in dt.Rows)
                {
                    string Username = row.Field<string>("UserName");
                    string Email = row.Field<string>("Email");

                    string template = @"Hi {0}, <br></br> To reset your password, click the link here : <br></br><a href='" + Url.Action("ResetPW", "Account", new { un = Username }, "http") + "'>Set your new password</a></button><br></br>" + "If you did not a request a password change, you can delete this email.<br></br>" + "Regards,<br></br>" + "<i>Tribe Accelerator</i>";

                    string title = "Password Change";
                    string message = String.Format(template, Username);

                    if (EmailUtl.SendEmail(email, title, message, out string result))
                    {
                        ViewData["Message"] = "Email Successfully Sent";
                        ViewData["MsgType"] = "success";
                        return View("ResetPWConfirm");
                    }

                    else
                    {
                        ViewData["Message"] = result;
                        ViewData["MsgType"] = "warning";
                    }
                }
            }
            else
            {
                ViewData["Message"] = "No such email exists.";
                ViewData["MsgType"] = "warning";
                return View("ResetPWEmail");
            }
            return View();
        }

        [AllowAnonymous]
        public bool VerifyEmail(String Email)
        {
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