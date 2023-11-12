using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanHang.Models.CustomModels
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
