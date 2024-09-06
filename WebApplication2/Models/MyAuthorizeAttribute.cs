using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    /// <summary>
    /// 若要自訂授權,可以繼承AuthorizeAttribute
    /// </summary>
    public class MyAuthorizeAttribute :AuthorizeAttribute
    {
        //指明哪些功能權限可以存取這個Action,例如"Book,User,Order"or"admin,manger" or "1,2,3"
        public string Functions { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // 若目前是已登入狀態
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // 如果 global.asax 忘了寫 Authenticate 事件，則這裡會無法順利轉型
                // 所以若這裡失敗，就去 global.asax 查原因
                CustomPrincipal currentUser = filterContext.HttpContext.User as CustomPrincipal;

                // 若 Functions 沒值，表示 action 上寫的只是 [MyAuthorize] 而不是 [MyAuthorize(Function="1,2")]
                // 表示只要有登入就能存取此 action
                if (string.IsNullOrEmpty(Functions)) return;

                string[] allowFunctions = Functions.Split(',')
                                                   .Select(x => x.Trim().ToLower())
                                                   .ToArray();

                // 判斷是否目前使用者有上述的功能權限
                if (allowFunctions.Any(f => currentUser.IsInRole(f))) return;

                // 若沒有權限，則導向到登入頁,以下二種寫法二擇一即可
                filterContext.Result = new RedirectResult("/Users/Login");
                return;

                // 若沒有權限，則導向到自訂的錯誤頁
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new
                        {
                            Controller = "Users",
                            Action = "NoPermission"
                        })
                );
            }

            base.OnAuthorization(filterContext);
        }
    }
}