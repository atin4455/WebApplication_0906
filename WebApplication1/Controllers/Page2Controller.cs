﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class Page2Controller : Controller
    {
        // GET: Page2
        public ActionResult Index()
        {
            return View();
        }      
        public ActionResult Index2()
        {
            return View();
        }
    }
}