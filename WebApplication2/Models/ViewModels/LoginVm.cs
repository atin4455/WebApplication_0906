using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.ViewModels
{
    public class LoginVm
    {
        [Display(Name ="帳號")]
        [Required]
        public string Account { get; set; }
        [Display(Name = "密碼")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}