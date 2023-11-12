using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Models.Entities;

namespace WebBanHang.Controllers
{
    public class ContactController : BaseController
    {
        public ContactController(IMapper mapper, WebBanHangContext db) : base(mapper, db)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
