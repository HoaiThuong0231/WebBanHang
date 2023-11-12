﻿using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models.LoginModels
{
    public class RegisterUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
