﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{

    public class BaseController : Controller
    {
        //
        // GET: /Base/
        public Database1Entities1 cx =new Database1Entities1();
        
        public BaseController()
        {
            
            
           
        }

    }
}
