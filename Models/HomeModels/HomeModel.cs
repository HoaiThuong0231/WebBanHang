using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Models.Entities;

namespace WebBanHang.Models.HomeModels
{
    public class HomeModel
    {
        public List<Product> ListProduct { set; get; }
        public List<Category> ListCategory { set; get; }

    }
}