using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Controllers;
using WebBanHang.Models.Entities;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class BrandController : BaseController
    {
        public BrandController(IMapper mapper, WebBanHangContext db) : base(mapper, db)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
