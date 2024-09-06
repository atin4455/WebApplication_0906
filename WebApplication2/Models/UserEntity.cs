using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class UserEntity
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string Functions { get; set; } //此功能擁有的功能清單,例如"1,4,6"
    }
}