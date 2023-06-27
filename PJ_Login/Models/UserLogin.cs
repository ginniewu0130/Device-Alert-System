﻿using System.ComponentModel.DataAnnotations;

namespace PJ_Login.Models
{
    public class UserLogin
    {
        [Key]
        [Display(Name = "序號")]
        public int UserId { get; set; }
        [Display(Name = "工號")]
        public string EmployeeId { get; set; }
        [Display(Name = "帳號")]
        public string Account { get; set; }
        [Display(Name = "密碼")]       
        public string Password { get; set; }

        //public string Role { get; set; }
    }
}
