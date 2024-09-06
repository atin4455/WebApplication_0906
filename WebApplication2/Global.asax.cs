using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebApplication2.Models;

namespace WebApplication2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(Object sender,EventArgs e)
        {
            //如果登入,不處理
            if(!Request.IsAuthenticated) return;

            //取得FormsIdentity
            var identity=(FormsIdentity)User.Identity;

            //然後取得認證票
            FormsAuthenticationTicket ticket=identity.Ticket;

            //取得票中的使用者資訊
            string functions = ticket.UserData;

            //建立一個自訂的使用者物件
            IPrincipal principal = new CustomPrincipal(identity, functions);

            //抽換成我們自己的使用者物件
            Context.User = principal;
        }
    }
}
