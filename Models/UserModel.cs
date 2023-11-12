using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models
{
    public class UserModel
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ")]
        [Display(Name = "Họ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Tên ")]
        [Display(Name = "Tên")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập  ")]
        [Display(Name = "Tên Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
    }

}