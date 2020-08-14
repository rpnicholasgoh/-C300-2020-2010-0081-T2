 using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FYP1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace FYP1.Controllers
{
    public class EventController : Controller
    {

        public IActionResult EventList()
        {
            List<Event> events = DBUtl.GetList<Event>(
              @"SELECT * FROM Events");

            return View(events);
        }
        
        public IActionResult EditEvent(int id)
        {
            string eventSql = @"SELECT *
                               FROM Events
                              WHERE Events.event_id = '{0}'";
            List<Event> list = DBUtl.GetList<Event>(eventSql, id);

            if (list.Count == 1)
            {
                return View(list[0]);
            }
            else
            {
                TempData["Message"] = "Event does not exist";
                TempData["MsgType"] = "warning";
                return RedirectToAction("EventList");
            }
        }

        [HttpPost]
        public IActionResult EditEvent(Event ev)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Invalid Input";
                ViewData["MsgType"] = "warning";
                return View("EditEvent");
            }
            else
            {
                int res = 0;
                string update;
                
                if (ev.document != null) //files
                {
                    string select = @"SELECT * FROM Events WHERE event_id={0}";
                    DataTable ds = DBUtl.GetTable(select, ev.event_id);
                    var docName = ds.Rows[0][ds.Columns.Count - 6].ToString();
                    //delete existing files
                    if (ValidUtl.CheckIfEmpty(docName) == false)
                    {
                        string remainingStr = docName;
                        string fullpath = "";
                        int detectNextLine = docName.IndexOf("\n");
                        int detectLastNextLine = docName.LastIndexOf("\n");
                        string docs = "";
                        if (detectNextLine == -1) // 1 file
                        {
                            fullpath = Path.Combine(_env.WebRootPath, "file/" + docName);
                            System.IO.File.Delete(fullpath);
                        }// working
                        else // >2 files
                        {
                            while (detectNextLine != -1)
                            {
                                docs = remainingStr.Substring(0, detectNextLine);
                                fullpath = Path.Combine(_env.WebRootPath, "file/" + docs);
                                System.IO.File.Delete(fullpath);
                                remainingStr = remainingStr.Substring(detectNextLine + 1);
                                detectNextLine = remainingStr.IndexOf("\n");
                            }
                            docs = docName.Substring(detectLastNextLine + 1);
                            fullpath = Path.Combine(_env.WebRootPath, "file/" + docs);
                            System.IO.File.Delete(fullpath);
                        }
                    }
                    //upload file
                    string fileNames = "";
                    for (int i = 0; i < ev.document.Length; i++)
                    {
                        string docfilename = DoPhotoUpload(ev.document[i]);
                        if (i == 0)
                        {
                            fileNames = fileNames + docfilename;
                        }

                        else
                        {
                            fileNames = fileNames + "\n" + docfilename;
                        }
                    }

                    update =
                  @"UPDATE Events
                    SET event_name='{1}', 
                        event_description='{2}', venue='{3}', category='{4}', start_dt='{5:yyyy-MM-dd HH:mm}', end_dt='{6:yyyy-MM-dd HH:mm}', docName='{7}', CompanyType ={8} 
                  WHERE event_id='{0}'";
                    res = DBUtl.ExecSQL(update, ev.event_id, ev.event_name, ev.event_description, ev.venue, ev.category,
                                                   ev.start_dt, ev.end_dt, fileNames, ev.CompanyType);


                }
                else
                {
                    update =
                  @"UPDATE Events
                    SET event_name='{1}', 
                        event_description='{2}', venue='{3}', category='{4}', start_dt='{5:yyyy-MM-dd HH:mm}', end_dt='{6:yyyy-MM-dd HH:mm}', CompanyType ={7}
                  WHERE event_id='{0}'";
                    res = DBUtl.ExecSQL(update, ev.event_id, ev.event_name, ev.event_description, ev.venue, ev.category,
                                                  ev.start_dt, ev.end_dt, ev.CompanyType);

                }
                
                if (res == 1)
                {
                    TempData["Message"] = "Event Updated";
                    TempData["MsgType"] = "success";
                }
                else
                {
                    TempData["Message"] = DBUtl.DB_Message;
                    TempData["MsgType"] = "danger";
                }

                return RedirectToAction("EventList");
                /*
                else
                {
                    
                    string update =
                   @"UPDATE Event
                    SET event_name='{1}', 
                        event_description='{2}', venue='{3}', start_date='{4:yyyy-MM-dd}', start_time='{5:HH:mm}', end_time='{6:HH:mm}', User_Type ='{7}' 
                  WHERE event_id='{0}'";
                    res = DBUtl.ExecSQL(update, ev.event_id, ev.event_name, ev.event_description, ev.venue, ev.start_date,
                                                    ev.start_time, ev.end_time, ev.User_Type);
                }
                


                if (res == 1)
                {
                    TempData["Message"] = "Event Updated";
                    TempData["MsgType"] = "success";
                }
                else
                {
                    TempData["Message"] = DBUtl.DB_Message;
                    TempData["MsgType"] = "danger";
                }
                return RedirectToAction("EventList");
                */
            }
        }

        public IActionResult DeleteEvent(int id)
        {
            string select = @"SELECT * FROM Events WHERE event_id={0}";
            DataTable ds = DBUtl.GetTable(select, id);
            if (ds.Rows.Count != 1)
            {
                TempData["Message"] = "Performance does not exist";
                TempData["MsgType"] = "warning";
            }
            else
            {
                var docName = ds.Rows[0][ds.Columns.Count - 6].ToString();
                if (ValidUtl.CheckIfEmpty(docName) == false)
                {
                    string remainingStr = docName;
                    string fullpath = "";
                    int detectNextLine = docName.IndexOf("\n");
                    int detectLastNextLine = docName.LastIndexOf("\n");
                    string docs = "";
                    if (detectNextLine == -1) // 1 file
                    {
                        fullpath = Path.Combine(_env.WebRootPath, "file/" + docName);
                        System.IO.File.Delete(fullpath);
                    }// working
                    else // >2 files
                    {
                        while (detectNextLine != -1)
                        {
                            docs = remainingStr.Substring(0, detectNextLine);
                            fullpath = Path.Combine(_env.WebRootPath, "file/" + docs);
                            System.IO.File.Delete(fullpath);
                            remainingStr = remainingStr.Substring(detectNextLine + 1);
                            detectNextLine = remainingStr.IndexOf("\n");
                        }
                        docs = docName.Substring(detectLastNextLine + 1);
                        fullpath = Path.Combine(_env.WebRootPath, "file/" + docs);
                        System.IO.File.Delete(fullpath);
                    }
                    
                    /*
                    if (detectNextLine > 0)
                    {
                        for(int i = 0; i < docName.Length; i++)
                        {
                            if(i == 1)
                            {
                                docs = docName.Substring(detectNextLine - 1);
                            }
                            else
                            {
                                docName = docName.Substring(detectNextLine + 2);
                                detectNextLine = docName.IndexOf("\n");
                                docs = docName.Substring(detectNextLine - 1);

                            }
                            fullpath = Path.Combine(_env.WebRootPath, "file/" + docs);
                        }                        
                    }
                    else
                    {
                        fullpath = Path.Combine(_env.WebRootPath, "file/" + docName);
                    }*/
                    
                    
                }

                string delete = "DELETE FROM Events WHERE event_id={0}";
                int res = DBUtl.ExecSQL(delete, id);

                //send email select string

                if (res == 1)
                {
                    TempData["Message"] = "Event Deleted";
                    TempData["MsgType"] = "success";

                    /*
                    //send email
                    string email = "panstrafy@gmail.com";
                    string subject = "Deletion of event";
                    string template = @"Hi {0},
                               <p>{1}</p>
                               <p>Your redemption code for free gift is NOTHING.</p>
                             Marketing Manager";
                    string body = String.Format(template, "Qistina", "Yayo");
                    string result;
                    if (EmailUtl.SendEmail(email, subject, body, out result))
                    {
                        ViewData["Message"] = "Email Successfully Sent";
                        ViewData["MsgType"] = "success";
                    }
                    else
                    {
                        ViewData["Message"] = result;
                        ViewData["MsgType"] = "warning";
                    }*/

                }
                else
                {
                    TempData["Message"] = DBUtl.DB_Message;
                    TempData["MsgType"] = "danger";
                }
            }
            return RedirectToAction("EventList");
        }

        public IActionResult AddEvent()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddEvent(Event newEvent)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Invalid Input";
                ViewData["MsgType"] = "warning";
                return View("AddEvent");
            }
            else
            {
                int result = 0;
                string insert = "";
                string fileNames = "";
                if (newEvent.document != null) //document present
                {
                    for(int i = 0; i < newEvent.document.Length; i++) //upload files
                    {
                        string docfilename = DoPhotoUpload(newEvent.document[i]);
                        if (i == 0)
                        {
                            fileNames = fileNames + docfilename;
                        }
                        else
                        {
                            fileNames = fileNames + "\n" + docfilename;
                        }
                        
                    }
                    
                    if (newEvent.repeat == "No") // dont repeat
                    {
                        insert =
              @"INSERT INTO Events(event_name, event_description, venue, category, start_dt, end_dt, docName, status, CompanyType) 
                 VALUES('{0}', '{1}', '{2}','{3}','{4:yyyy-MM-dd HH:mm}', '{5:yyyy-MM-dd HH:mm}', '{6}', '{7}', {8} )";
                        result = DBUtl.ExecSQL(insert, newEvent.event_name, newEvent.event_description, newEvent.venue, newEvent.category,
                                                 newEvent.start_dt, newEvent.end_dt, fileNames, "Upcoming", newEvent.CompanyType);
                    }
                    else // repeats
                    {
                        insert =
             @"INSERT INTO Events(event_name, event_description, venue, category, start_dt, end_dt, docName, repeatOnNo, repeatOnType, occurence, status, CompanyType) 
                 VALUES('{0}', '{1}', '{2}','{3}', '{4:yyyy-MM-dd HH:mm}', '{5:yyyy-MM-dd HH:mm}', '{6}' , {7}, '{8}',  {9}, '{10}',  {11}  )";
                        for (int i = 1; i <= newEvent.occurence; i++)
                        {
                            if (i == 1)
                            {
                                string name = newEvent.event_name + "(" + i + ")";
                                DBUtl.ExecSQL(insert, name, newEvent.event_description, newEvent.venue, newEvent.category,
                                                     newEvent.start_dt, newEvent.end_dt, fileNames, newEvent.repeatOnNo, newEvent.repeatOnType, newEvent.occurence, "Upcoming", newEvent.CompanyType);
                            }
                            else
                            {
                                string name = newEvent.event_name + "(" + (i - 1) + ")";
                                string select = @"SELECT * FROM Events WHERE event_name='{0}'";
                                DataTable ds = DBUtl.GetTable(select, name);

                                DateTime start = Convert.ToDateTime(ds.Rows[0][ds.Columns.Count - 8].ToString());
                                DateTime end = Convert.ToDateTime(ds.Rows[0][ds.Columns.Count - 7].ToString());

                                //int repeatOnNo = Convert.ToInt32(newEvent.repeatOnNo);

                                if (newEvent.repeatOnType == "week")
                                {
                                    start = start.AddDays(newEvent.repeatOnNo * 7);
                                    end = end.AddDays(newEvent.repeatOnNo * 7);
                                }
                                else if (newEvent.repeatOnType == "day")
                                {
                                    start = start.AddDays(newEvent.repeatOnNo);
                                    end = end.AddDays(newEvent.repeatOnNo);
                                }
                                else if (newEvent.repeatOnType == "month")
                                {
                                    start = start.AddMonths(newEvent.repeatOnNo);
                                    end = end.AddMonths(newEvent.repeatOnNo);
                                }
                                else
                                {
                                    start = start.AddYears(newEvent.repeatOnNo);
                                    end = end.AddYears(newEvent.repeatOnNo);
                                }
                                name = newEvent.event_name + "(" + i + ")";
                                DBUtl.ExecSQL(insert, name, newEvent.event_description, newEvent.venue, newEvent.category,
                                                     start, end, fileNames, newEvent.repeatOnNo, newEvent.repeatOnType, newEvent.occurence, "Upcoming", newEvent.CompanyType);
                            }
                            result = 1;
                        }

                    }
                }
                if (newEvent.document == null)
                {
                    insert =
             @"INSERT INTO Events(event_name, event_description, venue, category, start_dt, end_dt, status, CompanyType) 
                 VALUES('{0}', '{1}', '{2}','{3}', '{4:yyyy-MM-dd HH:mm}', '{5:yyyy-MM-dd HH:mm}', '{6}', {7} )";
                    if (newEvent.repeat == "No")
                    {
                        result = DBUtl.ExecSQL(insert, newEvent.event_name, newEvent.event_description, newEvent.venue, newEvent.category,
                                                 newEvent.start_dt, newEvent.end_dt, "Upcoming", newEvent.CompanyType);
                    }
                    else
                    {
                        insert =
             @"INSERT INTO Events(event_name, event_description, venue, 
category, start_dt, end_dt, 
repeatOnNo, repeatOnType, occurence, status, CompanyType) 
                 VALUES('{0}', '{1}', '{2}',
'{3}', '{4:yyyy-MM-dd HH:mm}', '{5:yyyy-MM-dd HH:mm}', 
{6}, '{7}',  {8}, '{9}',  {10}  )";
                        for (int i = 1; i <= newEvent.occurence; i++)
                        {
                            if (i == 1)
                            {
                                string name = newEvent.event_name + "(" + i + ")";
                                DBUtl.ExecSQL(insert, name, newEvent.event_description, newEvent.venue, newEvent.category,
                                                     newEvent.start_dt, newEvent.end_dt, newEvent.repeatOnNo, newEvent.repeatOnType, newEvent.occurence, "Upcoming", newEvent.CompanyType);
                            }
                            else
                            {
                                string name = newEvent.event_name + "(" + (i - 1) + ")";
                                string select = @"SELECT * FROM Events WHERE event_name='{0}'";
                                DataTable ds = DBUtl.GetTable(select, name);

                                DateTime start = Convert.ToDateTime(ds.Rows[0][ds.Columns.Count - 8].ToString());
                                DateTime end = Convert.ToDateTime(ds.Rows[0][ds.Columns.Count - 7].ToString());

                                //int repeatOnNo = Convert.ToInt32(newEvent.repeatOnNo);

                                if (newEvent.repeatOnType == "week")
                                {
                                    start = start.AddDays(newEvent.repeatOnNo * 7);
                                    end = end.AddDays(newEvent.repeatOnNo * 7);
                                }
                                else if (newEvent.repeatOnType == "day")
                                {
                                    start = start.AddDays(newEvent.repeatOnNo);
                                    end = end.AddDays(newEvent.repeatOnNo);
                                }
                                else if (newEvent.repeatOnType == "month")
                                {
                                    start = start.AddMonths(newEvent.repeatOnNo);
                                    end = end.AddMonths(newEvent.repeatOnNo);
                                }
                                else
                                {
                                    start = start.AddYears(newEvent.repeatOnNo);
                                    end = end.AddYears(newEvent.repeatOnNo);
                                }
                                name = newEvent.event_name + "(" + i + ")";
                                DBUtl.ExecSQL(insert, name, newEvent.event_description, newEvent.venue, newEvent.category,
                                                     start, end, newEvent.repeatOnNo, newEvent.repeatOnType, newEvent.occurence, "Upcoming", newEvent.CompanyType);
                            }
                            result = 1;
                        }

                    }

                }
                if (result == 1)
                {
                    TempData["Message"] = "Event Created";
                    TempData["MsgType"] = "success";
                }
                else
                {
                    TempData["Message"] = DBUtl.DB_Message;
                    TempData["MsgType"] = "danger";
                }
                return RedirectToAction("EventList");
            }
            
        }
        public IActionResult EventDetails(int id)
        {
            string eventSql = @"SELECT *
                               FROM Events
                              WHERE Events.event_id = '{0}'";
            List<Event> list = DBUtl.GetList<Event>(eventSql, id);
            Event ev = list[0];
            if (list.Count == 1)
            {
                return View("EventDetails", ev);
            }
            else
            {
                TempData["Message"] = "Event does not exist";
                TempData["MsgType"] = "warning";
                return RedirectToAction("EventList");
            }
        }







        private string DoPhotoUpload(IFormFile doc)
        {
            
                string fileName = Path.GetFileNameWithoutExtension(doc.FileName);
                string fext = Path.GetExtension(doc.FileName);
                //string uname = Guid.NewGuid().ToString();
                //string fname = uname + fext;
                string fileNameExt = fileName + fext;
                string fullpath = Path.Combine(_env.WebRootPath, "file/" + fileNameExt);
                using (FileStream fs = new FileStream(fullpath, FileMode.Create))
                {
                    doc.CopyTo(fs);
                }
            
            return fileNameExt;

        }

        private IWebHostEnvironment _env;
        public EventController(IWebHostEnvironment environment)
        {
            _env = environment;
        }
    }
}
