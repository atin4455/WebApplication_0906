using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Service
{
    public class UserService
    {
        public bool IsVaild(string account , string password)
        {
            //to do 連結到db進行驗證

            //在此只示意的寫
            return account  == "admin" && password == "123";
        }
    }
}