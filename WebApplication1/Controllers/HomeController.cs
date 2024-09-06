using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVm formData)
        {
            if (FormsAuthentication.Authenticate(formData.Account, formData.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(formData.Account, false);

                return null;
            }
            else
            {
                ModelState.AddModelError(string.Empty, "帳號或密碼有誤");
                return View();
            }

        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}