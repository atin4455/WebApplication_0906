using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebApplication2.Models
{
    public class CustomPrincipal : IPrincipal
    {
        private string[] _functions;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="能操作的功能,例如BOOK USER ORDER"></param>
        public CustomPrincipal(IIdentity identity,string functions) 
        {
         _functions=functions.Split(',').Select(x => x.Trim().ToLower()).ToArray();

            this.Identity = identity;
        }



        public IIdentity Identity {  get; private set; }    

        public bool IsInRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                return false;
            }

            return _functions.Contains(role.Trim().ToLower());
        }
    }
}