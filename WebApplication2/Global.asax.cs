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
            //�p�G�n�J,���B�z
            if(!Request.IsAuthenticated) return;

            //���oFormsIdentity
            var identity=(FormsIdentity)User.Identity;

            //�M����o�{�Ҳ�
            FormsAuthenticationTicket ticket=identity.Ticket;

            //���o�������ϥΪ̸�T
            string functions = ticket.UserData;

            //�إߤ@�Ӧۭq���ϥΪ̪���
            IPrincipal principal = new CustomPrincipal(identity, functions);

            //�⴫���ڭ̦ۤv���ϥΪ̪���
            Context.User = principal;
        }
    }
}
