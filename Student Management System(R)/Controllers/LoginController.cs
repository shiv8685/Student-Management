using Student_Management_System_R_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management_System_R_.Controllers
{
    public class LoginController : Controller
    {
        studentDbContext db=new studentDbContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User objchek)
        {
            if(ModelState.IsValid)
            {
                using(studentDbContext db = new studentDbContext())
                {
                    var obj = db.Users.Where(a => a.UserName.Equals(objchek.UserName) && a.Password.Equals(objchek.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The UserName or Password Incorrect");

                    }
                }
            }            
            return View(objchek);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}