using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using WebApplication2.Models;
using WebApplication2.Models.ViewModels;

namespace WebApplication2.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginVm vm)
        {
            {
                if (!IsValid(vm.Account, vm.Password))
                {
                    ModelState.AddModelError("", "帳號或密碼錯誤");
                }

                if (!ModelState.IsValid)
                {
                    return View(vm);
                }
            }

            //如果帳號密碼正確,則建立一個登入用的Cookie
            HttpCookie cookie;
            var returnUrl=ProcessLogin(vm.Account,false,out cookie);

            Response.Cookies.Add(cookie);

            return Redirect(returnUrl);
             }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        private string ProcessLogin(string account, bool rememberMe, out HttpCookie cookie)
        {
            string functions = _allUsers.First(u => u.Account == account).Functions;//此使用者擁有的功能清單，例如"1,4,6"
           //建立一張認證票
            FormsAuthenticationTicket ticket =
                new FormsAuthenticationTicket(
                1,              //版本別，沒別的用處
                account,
                DateTime.Now,   //發行日
                DateTime.Now.AddDays(2),//到期日
                rememberMe,     //是否續存
                functions,      //userdata
                "/"             //cookie位置
                );
            //將它加密
            string value = FormsAuthentication.Encrypt(ticket);
            //存入cookie
            cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value);
            //取得return url
            string url = FormsAuthentication.GetRedirectUrl(account, true);//第二個引數沒有用處
            return url;
        }

        List<UserEntity> _allUsers = new List<UserEntity>()
        {
            new UserEntity() {Account="tim",Password="123",Functions="1,2,4"},
            new UserEntity() {Account="eddie",Password="123",Functions="3,4"},
            new UserEntity() {Account="simon",Password="123",Functions="1,2,3"},
            new UserEntity() {Account="allen",Password="123",Functions="1,2,3,4"},
        };


        private bool IsValid(string account, string password)
        {
            var user=_allUsers.FirstOrDefault(x=>x.Account==account&&x.Password==password);
            return (user != null);
        }
    }
}