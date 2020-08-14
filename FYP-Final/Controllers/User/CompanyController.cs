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

        [Authorize(Roles ="Admin")]
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
                //TempData["Message"] = "Account Created";
                //TempData["MsgType"] = "success";
                string insert = @"INSERT INTO Email(Email, EmailStatus)VALUES('{0}',0)";
                string insert1 = @"INSERT INTO AppUser(UserName, User_PW, RepName, Contact_Num, CompanyName, CompanyWebsite, CompanyIndustry, CompanySize, CompanyType, Email) VALUES('{0}', HASHBYTES('SHA1', '{1}'), '{2}', {3}, '{4}', '{5}', '{6}', '{7}', 2, '{8}')";
                        //@"INSERT INTO ACCOUNT(CompanyName, CompanyWebsite, CompanyIndustry, CompanySize, Company_Type, UserName, User_PW, RepName, Contact_Num, Email) VALUES('{0}', '{1}', '{2}', '{3}', 'Current', '{5}', HASHBYTES('SHA1', '{6}'), '{7}', {8}, '{9}')";
                if (DBUtl.ExecSQL(insert, company.Email) == 1)
                {
                
                    if (DBUtl.ExecSQL(insert1, company.UserName, company.User_PW, company.RepName, company.Contact_Num, company.CompanyName, company.CompanyWebsite, company.CompanyIndustry, company.CompanySize, company.Email) == 1)
                    {
                        ViewData["Message"] = "Company Successfully Created";
                        ViewData["MsgType"] = "success";
                        return View("Activate");
                    }

                //    string template = @"Hi {0}!<br><br/>
                //Welcome to Tribe Accelerator! To confirm your account, please click the link below. <a href='/Company/Activate' />";
                //    string title = "Account Confirmation";
                //    string message = String.Format(template, company.CompanyName);
                //    string result = "";

                //    bool outcome = false;
                //    outcome = EmailUtl.SendEmail(company.Email, title, message, out result);

                //    if (outcome == true)
                //    {
                    else
                    {
                        ViewData["Message"] = DBUtl.DB_Message;
                        ViewData["MsgType"] = "warning";
                    }
                }
                return View("Activate");
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string name)
        {
            //string userSQL = @"SELECT * FROM Account WHERE CompanyID = {0}";
            string userSQL = @"SELECT UserName, CompanyName, CompanyType FROM AppUser WHERE UserName = '{0}'";

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
                //string update = @"UPDATE Account SET Company_Type = '{1}' WHERE CompanyID = {0}";
                string update = @"UPDATE AppUser SET CompanyType = {1} WHERE UserName = '{0}'";
                int res = DBUtl.ExecSQL(update, edit.UserName, edit.CompanyType);

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
            //string select = @"SELECT * FROM Account WHERE CompanyID={0}";
            string select = @"SELECT * FROM AppUser WHERE UserName='{0}'";
            DataTable ds = DBUtl.GetTable(select, name);

            if (ds.Rows.Count != 1)
            {
                TempData["Message"] = "Company Record No Longer Exists.";
                TempData["MsgType"] = "warning";
            }

            else
            {
                //string delete = "DELETE FROM Account WHERE CompanyID ={0}";
                string delete = "DELETE FROM AppUser WHERE UserName='{0}'";
                string delete1 = "DELETE FROM Email WHERE Email='{0}'";
                int res = DBUtl.ExecSQL(delete,  name);
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


        //private List<Company> GetList()
        //{
        //    string companySQL = @"SELECT * FROM AppUser";
        //    List<Company> stUser = DBUtl.GetList<Company>(companySQL);

        //    return stUser;
        //}
    }
}