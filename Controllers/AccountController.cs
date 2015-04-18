using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Web.Mail;
using System.Web.Mvc;
using MvcApplication2.Models;
namespace MvcApplication2.Controllers
{
    
    public class AccountController : Controller
    {
        Database1Entities2 db = new Database1Entities2();
        
        
        @base c = new @base();
        List<userCTag> lt1;
        contactandtags ct;
        List<Contact> cl;

        //
        Database1Entities1 cx = new Database1Entities1();
       
        // GET: /Account/

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult iCloud()
        {
            return View();
        }
        public ActionResult signin()
        {
            cl = new List<Contact>();
            
            ct = new contactandtags(null,null, cl);
            // return Redirect("../User/ProfilePage");

            return View(ct);
        }
        public ActionResult signup()
        {
            cl = new List<Contact>();
      
            ct = new contactandtags(null,null, cl);

            // return Redirect("../User/ProfilePage");

            return View(ct);
        }
        public JsonResult validateSignin(String u, String p)
        {
            try
            {
                List<login> q = db.logins.Where(x => x.userName.Equals(u) && x.password.Equals(p)).ToList();
                login a=null;
                if (q.Count>0)
                {
                     a= q.First();
                     Session["username"] = u;
                     Session["userId"] = a.Id;
                    return this.Json(true, JsonRequestBehavior.AllowGet);
                }
                else { 
               
                return this.Json(false, JsonRequestBehavior.AllowGet);

                }
            }
            catch
            {
                return this.Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult Availability(String u)
        {
            try
            {
                List<login> cl = db.logins.Where(x => x.userName.Equals(u)).ToList();
                

                if (cl.Count>0)
                    return this.Json(true, JsonRequestBehavior.AllowGet);
                else
                    return this.Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return this.Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult validateSignup(login a )
        {
            a.lastName = "Not Available";
            a.isActive = 1;
            
         
            db.logins.Add(a);
            db.SaveChanges();
            

           
            return Redirect("../Account/signin");
        }

        public ActionResult logout()
        {
            Session.RemoveAll();
            return Redirect("../Account/signin");

        }

    }
}
