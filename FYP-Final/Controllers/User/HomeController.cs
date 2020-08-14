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

namespace FYP1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult FeedbackForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Send()
        {
            for (int i = 0; i < 5; i++)
            {
                List<Email> list = DBUtl.GetList<Email>("SELECT Email FROM , WHERE ");
            }
            return View("SendFeedback");
        }


        public IActionResult SubmitFeedbackForm()
        {
            return RedirectToAction("FeedbackForm");
        }


        [HttpPost]
        public IActionResult SubmitFeedbackPost(string answer)
        {
            // Retrieve the text data from the form
            IFormCollection form = HttpContext.Request.Form;
            string ans1 = form["group1"].ToString();
            string ans2 = form["group2"].ToString();
            string ans3 = form["text1"].ToString();
            string ans4 = form["group3"].ToString();
            string ans5 = form["group4"].ToString();
            string ans6 = form["group5"].ToString();
            string ans7 = form["group6"].ToString();
            string ans8 = form["group7"].ToString();
            string ans9 = form["group8"].ToString();
            string ans10 = form["group9"].ToString();
            string ans11 = form["group10"].ToString();
            string ans12 = form["text2"].ToString();
            string ans13 = form["group11"].ToString();
            string ans14 = form["group12"].ToString();
            string ans15 = form["group13"].ToString();
            string ans16 = form["group14"].ToString();
            string ans17 = form["group15"].ToString();
            string ans18 = form["group16"].ToString();
            string ans19 = form["group17"].ToString();
            string ans20 = form["text3"].ToString();
            string ans21 = form["text4"].ToString();
            string ans22 = form["text5"].ToString();



            // Write the SQL to insert the record into the database
            string insertSql = @"INSERT INTO FeedbackAns(answer1, answer2, answer3, answer4, answer5, answer5, answer6, answer7, answer8, answer9, answer10, answer11, answer12, answer13, answer14, answer15, answer16, answer17, answer18, answer19, answer20, answer21, answer22)
              VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}')";
            string stmt = String.Format(insertSql, ans1, ans2, ans3, ans4, ans5, ans6, ans7, ans8, ans9, ans10, ans11, ans12, ans13, ans14, ans15, ans16, ans17, ans18, ans19, ans20, ans21, ans22);

            // Execute the SQL
            // Check if the SQL was successful. 
            //     If successful redirect to the 'Successful' action
            //     If failure show the DB_Message and return to the 'ProviderAdd' view
            if (DBUtl.ExecSQL(stmt) == 1)
            {
                TempData["Message"] = "Response Successfully Added.";
                TempData["MsgType"] = "success";
                return RedirectToAction("Successful");
            }
            else
            {
                ViewData["Message"] = DBUtl.DB_Message;
                ViewData["MsgType"] = "danger";
                return View("FeedbackForm");
            }
        }
        /*
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}