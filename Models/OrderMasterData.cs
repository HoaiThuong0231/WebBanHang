using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models
{
    public class OrderMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mã đơn hàng")]
        [Display(Name = "Mã đơn hàng")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Id người mua")]
        public Nullable<int> UserId { get; set; }
        [Required]
        [Display(Name = "Tình trạng")]
        public Nullable<int> Status { get; set; }
        [Required]
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
    }
}