using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        @base c = new @base();
        List<userCTag> lt1;
        contactandtags ct;

        Database1Entities1 cx = new Database1Entities1();
        Database1Entities2 db = new Database1Entities2();
        public ActionResult Index()
        {
            List<Contact> cl = new List<Contact>();
            

           
            ct = new contactandtags(null, null, cl);
            
            return View(ct);
          
        }
        
        public ActionResult gettags()
        {
            var lt = cx.Contacts.ToList();
             return PartialView("_Layout",lt);
            }
        public ActionResult Contacts()
        {
            return View();
        }

    }
}
