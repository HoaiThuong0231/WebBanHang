using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models
{
    public class BrandMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên mật khẩu")]
        [Display(Name = "Tên Thương hiệu")]
        public string Name { get; set; }
        [Display(Name = "Hình đại diện")]
        public string Avatar { get; set; }
        public string Slug { get; set; }
        [Display(Name = "Hiển thị trang chủ")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        [Display(Name = "Thứ tự hiễn thị")]
        public Nullable<int> DisplayOrder { get; set; }
        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
}