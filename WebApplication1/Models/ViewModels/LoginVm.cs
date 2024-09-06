using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LoginVm
    {
        [Required]
        public string Account { get; set; }

        public string Password { get; set; }
    }
}