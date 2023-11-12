using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Models.Entities;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public HomeController(IMapper mapper, WebBanHangContext db) : base(mapper, db)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
