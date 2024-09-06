using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using WebApplication1.Models;
using WebApplication1.Models.Service;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginVm formData)
        {
            if(ModelState.IsValid==false)
            {
                return View(formData);
            }


            var service = new UserService();
            if (service.IsVaild(formData.Account, formData.Password))
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

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }


        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
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