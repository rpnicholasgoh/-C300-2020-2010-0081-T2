using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NETCore.MailKit.Core;
using Microsoft.AspNetCore.Identity;
using FYP1.Models;

namespace FYP1.Controllers
{
    public class CompanyController : Controller
    {

        [AllowAnonymous]
        public IActionResult Forbidden()
        {
            return View("Forbidden", "Account");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Company company)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Invalid Input";
                ViewData["MsgType"] = "warning";
                return View("Create");
            }

            else
            {
                string insert = @"INSERT INTO Email(Email, EmailStatus) VALUES('{0}',0)";
                string insert1 = @"INSERT INTO AppUser(UserName, User_PW, RepName, Contact_Num, CompanyName, CompanyWebsite, CompanyIndustry, CompanySize, CompanyType, Email) VALUES('{0}', HASHBYTES('SHA1', '{1}'), '{2}', {3}, '{4}', '{5}', '{6}', '{7}', 2, '{8}')";

                int result = DBUtl.ExecSQL(insert, company.Email);
                int result1 = DBUtl.ExecSQL(insert1, company.UserName, company.User_PW, company.RepName, company.Contact_Num, company.CompanyName, company.CompanyWebsite, company.CompanyIndustry, company.CompanySize, company.Email);


                if (result == 1 && result1 == 1)
                {
                    TempData["Mesage"] = "Account Created";
                    TempData["MsgType"] = "success";

                    string email = company.Email.ToString();
                    string select = "SELECT * FROM AppUser WHERE Email='{0}'";
                    DataTable dt = DBUtl.GetTable(select, email);

                    foreach (DataRow row in dt.Rows)
                    {
                        string RepName = row.Field<string>("RepName");
                        string Email = row.Field<string>("Email");
                        string UserName = row.Field<string>("UserName");

                        string template = @"Hi {0}, <br></br> Welcome to Tribe Accelerator! Your username is {1}. To activate your account, click here <button><a href='" + Url.Action("Activate", "Company", new { un = Email }, "http") + "'>Activate</a></button><br></br>" + "Regards,<br></br> The Tribe Accelerator team";
                        string title = "Account Activation";
                        string message = string.Format(template, RepName, UserName);
                        string rs;
                        if (EmailUtl.SendEmail(email, title, message, out rs))
                        {
                            ViewData["Message"] = "Email successfully sent";
                            ViewData["MsgType"] = "success";
                        }
                        else
                        {
                            ViewData["Message"] = result;
                            ViewData["MsgType"] = "warning";
                        }
                        return View("Confirmation");
                    }
                }
                else
                {
                    TempData["Message"] = DBUtl.DB_Message;
                    TempData["MsgType"] = "danger";
                }
                return Redirect("~/Home/Index");
            }
        }

        public IActionResult Activate(string un)
        {
            string sql = $"UPDATE Email SET EmailStatus = 1 WHERE Email = '{un}'";
            int db = DBUtl.ExecSQL(sql);
            return View();
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string name)
        {
            string userSQL = @"SELECT UserName, RepName, Contact_Num, CompanyName, CompanyWebsite, CompanyIndustry, CompanySize, CompanyType, Email FROM AppUser WHERE UserName = '{0}'";

            List<Edit> stUser = DBUtl.GetList<Edit>(userSQL, name);

            if (stUser.Count == 1)
            {
                //ViewData["Company"] = List();
                return View(stUser[0]);
            }

            else
            {
                TempData["Message"] = "User Not Found.";
                TempData["MsgType"] = "warning";
                return RedirectToAction("List");
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Edit edit)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Invalid Input";
                ViewData["MsgType"] = "warning";
                return View("Edit");
            }

            else
            {
                string update = @"UPDATE AppUser SET CompanyType = {1}, RepName = '{2}', Contact_Num = {3}, CompanyName = '{4}', CompanyWebsite = '{5}', CompanyIndustry = '{6}', CompanySize = '{7}', Email = '{8}'  WHERE UserName = '{0}'";
                int res = DBUtl.ExecSQL(update, edit.UserName, edit.CompanyType, edit.RepName, edit.Contact_Num, edit.CompanyName, edit.CompanyWebsite, edit.CompanyIndustry, edit.CompanySize, edit.Email);

                if (res == 1)
                {
                    TempData["Message"] = "Company Updated";
                    TempData["MsgType"] = "success";
                    return RedirectToAction("List");
                }

                else
                {
                    TempData["Message"] = DBUtl.DB_Message;
                    TempData["MsgType"] = "danger";
                    return View("Edit");
                }


            }
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string name, string email)
        {

            string select = @"SELECT * FROM AppUser WHERE UserName='{0}'";
            DataTable ds = DBUtl.GetTable(select, name);

            if (ds.Rows.Count != 1)
            {
                TempData["Message"] = "Company Record No Longer Exists.";
                TempData["MsgType"] = "warning";
            }

            else
            {

                string delete = "DELETE FROM AppUser WHERE UserName='{0}'";
                string delete1 = "DELETE FROM Email WHERE Email='{0}'";
                int res = DBUtl.ExecSQL(delete, name);
                int res1 = DBUtl.ExecSQL(delete1, email);

                if (res == 1)
                {
                    TempData["Message"] = "Company Deleted.";
                    TempData["MsgType"] = "success";
                }

                else
                {
                    TempData["Message"] = DBUtl.DB_Message;
                    TempData["MsgType"] = "danger";
                }
            }
            return RedirectToAction("List");
        }

        [Authorize]
        public IActionResult List()
        {
            List<Company> company = DBUtl.GetList<Company>(
                            @"SELECT * FROM AppUser");

            return View(company);
        }
    }
}