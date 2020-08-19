using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FYP1.Controllers
{
   public class ChartController : Controller
   {

        //Use [AllowAnonymous] or [Authorise] to specify access control

        [Authorize(Roles = "Admin")]
        public IActionResult Rating1()
        {
         PrepareData(1); 
         ViewData["Chart"] = "pie";
         ViewData["Title"] = "1. How satisfied were you with the event?";
         ViewData["ShowLegend"] = "true";
         return View("Summary");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Rating2()
        {
         
         PrepareData(2); 
         ViewData["Chart"] = "pie";
         ViewData["Title"] = "2. How relevant and helpful do you think it was for your job?";
         ViewData["ShowLegend"] = "true";
         return View("Summary");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Rating3()
        {
         
         PrepareData(3); 
         ViewData["Chart"] = "pie";
         ViewData["Title"] = "4. How satisfied were you with the logistics? (Accommodation)";
         ViewData["ShowLegend"] = "true";
         return View("Summary");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Rating4()
        {
            
            PrepareData(4); 
            ViewData["Chart"] = "pie";
            ViewData["Title"] = "4. How satisfied were you with the logistics? (Welcome Kit)";
            ViewData["ShowLegend"] = "true";
            return View("Summary");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Rating5()
        {
            
            PrepareData(5); 
            ViewData["Chart"] = "pie";
            ViewData["Title"] = "4. How satisfied were you with the logistics? (Communication emails)";
            ViewData["ShowLegend"] = "true";
            return View("Summary");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Rating6()
        {
            
            PrepareData(6); 
            ViewData["Chart"] = "pie";
            ViewData["Title"] = "4. How satisfied were you with the logistics? (Transportation)";
            ViewData["ShowLegend"] = "true";
            return View("Summary");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Rating7()
        {
            
            PrepareData(7); 
            ViewData["Chart"] = "pie";
            ViewData["Title"] = "4. How satisfied were you with the logistics? (Welcome activity)";
            ViewData["ShowLegend"] = "true";
            return View("Summary");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Rating8()
        {
            
            PrepareData(8); 
            ViewData["Chart"] = "pie";
            ViewData["Title"] = "4. How satisfied were you with the logistics? (Venue)";
            ViewData["ShowLegend"] = "true";
            return View("Summary");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Rating9()
        {
            
            PrepareData(9); 
            ViewData["Chart"] = "pie";
            ViewData["Title"] = "4. How satisfied were you with the logistics? (Activities)";
            ViewData["ShowLegend"] = "true";
            return View("Summary");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Rating10()
        {
            
            PrepareData(10); 
            ViewData["Chart"] = "pie";
            ViewData["Title"] = "4. How satisfied were you with the logistics? (Closing ceremony)";
            ViewData["ShowLegend"] = "true";
            return View("Summary");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Rating11()
        {
            
            PrepareData(11);
            ViewData["Chart"] = "pie";
            ViewData["Title"] = "6. Which sessions did you find most relevant? (Welcome Activity)";
            ViewData["ShowLegend"] = "true";
            return View("Summary");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Rating12()
        {
            
            PrepareData(12); 
            ViewData["Chart"] = "pie";
            ViewData["Title"] = "6. Which sessions did you find most relevant? (Speaker #1)";
            ViewData["ShowLegend"] = "true";
            return View("Summary");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Rating13()
        {
         
            PrepareData(13); 
            ViewData["Chart"] = "pie";
            ViewData["Title"] = "6. Which sessions did you find most relevant? (Activity #1)";
            ViewData["ShowLegend"] = "true";
            return View("Summary");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Rating14()
        {
            
            PrepareData(14); 
            ViewData["Chart"] = "pie";
            ViewData["Title"] = "6. Which sessions did you find most relevant? (Speaker #2)";
            ViewData["ShowLegend"] = "true";
            return View("Summary");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Rating15()
        {
            
            PrepareData(15); 
            ViewData["Chart"] = "pie";
            ViewData["Title"] = "6. Which sessions did you find most relevant? (Activity #2)";
            ViewData["ShowLegend"] = "true";
            return View("Summary");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Rating16()
        {
            
            PrepareData(16); 
            ViewData["Chart"] = "pie";
            ViewData["Title"] = "6. Which sessions did you find most relevant? (Closing Activity)";
            ViewData["ShowLegend"] = "true";
            return View("Summary");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Rating17()
        {
            
            PrepareData(17); 
            ViewData["Chart"] = "pie";
            ViewData["Title"] = "7. How satisfied were you with the session content?";
            ViewData["ShowLegend"] = "true";
            return View("Summary");
        }

        private void PrepareData(int x)
      {
         int[] rating1 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating2 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating3 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating4 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating5 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating6 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating7 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating8 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating9 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating10 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating11 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating12 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating13 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating14 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating15 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating16 = new int[] { 0, 0, 0, 0, 0 };
         int[] rating17 = new int[] { 0, 0, 0, 0, 0 };
         
         List<FYP1.Models.Answer> list = DBUtl.GetList<FYP1.Models.Answer>("SELECT answer1, answer2, answer4, answer5, answer6, answer7, answer8, answer9, answer10, answer11, answer13, answer14, answer15, answer16, answer17, answer18, answer19 FROM FeedbackAns");
         foreach (FYP1.Models.Answer ans in list)
         {
            if (ans.answer1 == "111") rating1[0]++;
            else if (ans.answer1 == "112") rating1[1]++;
            else if (ans.answer1 == "113") rating1[2]++;
            else if (ans.answer1 == "114") rating1[3]++;
            else rating1[4]++;

            if (ans.answer2 == "211") rating2[0]++;
            else if (ans.answer2 == "212") rating2[1]++;
            else if (ans.answer2 == "213") rating2[2]++;
            else if (ans.answer2 == "214") rating2[3]++;
            else rating2[4]++;

            if (ans.answer4 == "411") rating3[0]++;
            else if (ans.answer4 == "412") rating3[1]++;
            else if (ans.answer4 == "413") rating3[2]++;
            else if (ans.answer4 == "414") rating3[3]++;
            else if (ans.answer4 == "415") rating3[4]++;
            else rating3[5]++;

            if (ans.answer5 == "421") rating4[0]++;
            else if (ans.answer5 == "422") rating4[1]++;
            else if (ans.answer5 == "423") rating4[2]++;
            else if (ans.answer5 == "424") rating4[3]++;
            else if (ans.answer5 == "425") rating4[4]++;
            else rating4[5]++;

            if (ans.answer6 == "431") rating5[0]++;
            else if (ans.answer6 == "432") rating5[1]++;
            else if (ans.answer6 == "433") rating5[2]++;
            else if (ans.answer6 == "434") rating5[3]++;
            else if (ans.answer6 == "434") rating5[4]++;
            else rating5[5]++;

            if (ans.answer7 == "441") rating6[0]++;
            else if (ans.answer7 == "442") rating6[1]++;
            else if (ans.answer7 == "443") rating6[2]++;
            else if (ans.answer7 == "444") rating6[3]++;
            else if (ans.answer7 == "445") rating6[4]++;
            else rating6[5]++;

            if (ans.answer8 == "451") rating7[0]++;
            else if (ans.answer8 == "452") rating7[1]++;
            else if (ans.answer8 == "453") rating7[2]++;
            else if (ans.answer8 == "454") rating7[3]++;
            else if (ans.answer8 == "455") rating7[4]++;
            else rating7[5]++;

            if (ans.answer9 == "461") rating8[0]++;
            else if (ans.answer9 == "462") rating8[1]++;
            else if (ans.answer9 == "463") rating8[2]++;
            else if (ans.answer9 == "464") rating8[3]++;
            else if (ans.answer9 == "465") rating8[4]++;
            else rating8[5]++;

            if (ans.answer10 == "471") rating9[0]++;
            else if (ans.answer10 == "472") rating9[1]++;
            else if (ans.answer10 == "473") rating9[2]++;
            else if (ans.answer10 == "474") rating9[3]++;
            else if (ans.answer10 == "475") rating9[3]++;
            else rating9[5]++;

            if (ans.answer11 == "481") rating10[0]++;
            else if (ans.answer11 == "482") rating10[1]++;
            else if (ans.answer11 == "483") rating10[2]++;
            else if (ans.answer11 == "484") rating10[3]++;
            else if (ans.answer11 == "485") rating10[4]++;
            else rating10[5]++;

            if (ans.answer13 == "611") rating11[0]++;
            else if (ans.answer13 == "612") rating11[1]++;
            else if (ans.answer13 == "613") rating11[2]++;
            else rating11[3]++;

            if (ans.answer14 == "621") rating12[0]++;
            else if (ans.answer14 == "622") rating12[1]++;
            else if (ans.answer14 == "623") rating12[2]++;
            else rating12[3]++;

            if (ans.answer15 == "631") rating13[0]++;
            else if (ans.answer15 == "632") rating13[1]++;
            else if (ans.answer15 == "633") rating13[2]++;
            else rating13[3]++;

            if (ans.answer16 == "641") rating14[0]++;
            else if (ans.answer16 == "642") rating14[1]++;
            else if (ans.answer16 == "643") rating14[2]++;
            else rating14[3]++;

            if (ans.answer17 == "651") rating15[0]++;
            else if (ans.answer17 == "652") rating15[1]++;
            else if (ans.answer17 == "653") rating15[2]++;
            else rating15[3]++;

            if (ans.answer18 == "661") rating16[0]++;
            else if (ans.answer18 == "662") rating16[1]++;
            else if (ans.answer18 == "663") rating16[2]++;
            else rating16[3]++;

            if (ans.answer19 == "711") rating17[0]++;
            else if (ans.answer19 == "712") rating17[1]++;
            else if (ans.answer19 == "713") rating17[2]++;
            else if (ans.answer19 == "714") rating17[3]++;
            else rating17[4]++;

            
         }

         if (x == 1)
         {
            ViewData["Legend"] = "Satisfaction by Rate";
            ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red" };
            ViewData["Labels"] = new[] { "Not Very", "Not", "Neutral", "Quite", "Very Much" };
            ViewData["Data"] = rating1;
         }

         else if (x == 2)
         {
                ViewData["Legend"] = "Satisfaction by Rate";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red" };
                ViewData["Labels"] = new[] { "Not Very", "Not", "Neutral", "Quite", "Very Much" };
                ViewData["Data"] = rating2;
         }

         else if (x == 3)
         {
                ViewData["Legend"] = "Satisfaction level";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red", "yellow" };
                ViewData["Labels"] = new[] { "Very Dissatisfied", "Dissatisfied", "Neutral", "Satisfied", "Very Satisfied", "N/A"};
                ViewData["Data"] = rating3;
         }

         else if (x == 4)
         {
                ViewData["Legend"] = "Satisfaction level";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red", "yellow" };
                ViewData["Labels"] = new[] { "Very Dissatisfied", "Dissatisfied", "Neutral", "Satisfied", "Very Satisfied", "N/A"};
                ViewData["Data"] = rating4;
         }

         else if (x == 5)
         {
                ViewData["Legend"] = "Satisfaction level";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red", "yellow" };
                ViewData["Labels"] = new[] { "Very Dissatisfied", "Dissatisfied", "Neutral", "Satisfied", "Very Satisfied", "N/A"};
                ViewData["Data"] = rating5;
         }

         else if (x == 6)
         {
                ViewData["Legend"] = "Satisfaction level";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red", "yellow" };
                ViewData["Labels"] = new[] { "Very Dissatisfied", "Dissatisfied", "Neutral", "Satisfied", "Very Satisfied", "N/A"};
                ViewData["Data"] = rating6;
         }

         else if (x == 7)
         {
                ViewData["Legend"] = "Satisfaction level";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red", "yellow" };
                ViewData["Labels"] = new[] { "Very Dissatisfied", "Dissatisfied", "Neutral", "Satisfied", "Very Satisfied", "N/A"};
                ViewData["Data"] = rating7;
         }

         else if (x == 8)
         {
                ViewData["Legend"] = "Satisfaction level";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red", "yellow" };
                ViewData["Labels"] = new[] { "Very Dissatisfied", "Dissatisfied", "Neutral", "Satisfied", "Very Satisfied", "N/A"};
                ViewData["Data"] = rating8;
         }

         else if (x == 9)
         {
                ViewData["Legend"] = "Satisfaction level";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red", "yellow" };
                ViewData["Labels"] = new[] { "Very Dissatisfied", "Dissatisfied", "Neutral", "Satisfied", "Very Satisfied", "N/A"};
                ViewData["Data"] = rating9;
         }

         else if (x == 10)
         {
                ViewData["Legend"] = "Satisfaction level";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red", "yellow" };
                ViewData["Labels"] = new[] { "Very Dissatisfied", "Dissatisfied", "Neutral", "Satisfied", "Very Satisfied", "N/A"};
                ViewData["Data"] = rating10;
         }

         else if (x == 11)
         {
                ViewData["Legend"] = "Level of Relevancy";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red" };
                ViewData["Labels"] = new[] { "Not relevant", "Relevant", "Very relevant", "Did not attend"};
                ViewData["Data"] = rating11;
         }

            else if (x == 12)
            {
                ViewData["Legend"] = "Level of Relevancy";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red" };
                ViewData["Labels"] = new[] { "Not relevant", "Relevant", "Very relevant", "Did not attend" };
                ViewData["Data"] = rating12;
            }
            else if (x == 13)
            {
                ViewData["Legend"] = "Level of Relevancy";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red" };
                ViewData["Labels"] = new[] { "Not relevant", "Relevant", "Very relevant", "Did not attend" };
                ViewData["Data"] = rating13;
            }
            else if (x == 14)
            {
                ViewData["Legend"] = "Satisfaction by Rate";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red" };
                ViewData["Labels"] = new[] { "Not Very", "Not", "Neutral", "Quite", "Very Much" };
                ViewData["Data"] = rating14;
            }
            else if (x == 15)
            {
                ViewData["Legend"] = "Satisfaction by Rate";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red" };
                ViewData["Labels"] = new[] { "Not Very", "Not", "Neutral", "Quite", "Very Much" };
                ViewData["Data"] = rating15;
            }
            else if (x == 16)
            {
                ViewData["Legend"] = "Satisfaction by Rate";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red" };
                ViewData["Labels"] = new[] { "Not Very", "Not", "Neutral", "Quite", "Very Much" };
                ViewData["Data"] = rating16;
            }

            else if (x == 17)
            {
                ViewData["Legend"] = "Satisfaction of Materials by Rate";
                ViewData["Colors"] = new[] { "violet", "green", "blue", "orange", "red" };
                ViewData["Labels"] = new[] { "Poor", "Slightly Poor", "Acceptable", "Good", "Excellent" };
                ViewData["Data"] = rating17;
            }

            else
            {
            ViewData["Legend"] = "Nothing";
            ViewData["Colors"] = new[] { "gray", "darkgray", "black" };
            ViewData["Labels"] = new[] { "X", "Y", "Z" };
            ViewData["Data"] = new int[] { 1, 2, 3};
         }

      }

   }

}