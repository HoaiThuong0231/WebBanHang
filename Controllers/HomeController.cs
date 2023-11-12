using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using WebBanHang.Controllers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebBanHang.Models.Entities;
using WebBanHang.Models.HomeModels;

namespace WebBanHang.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IMapper mapper, WebBanHangContext db) : base(mapper, db)
        {
        }

        public async Task<ActionResult> Index()
        {
            HomeModel home = new HomeModel();
            home.ListProduct = await _db.Product.Include(x=>x.Review).ToListAsync();
            home.ListCategory =await _db.Category.ToListAsync();
            return View(home);
        }
    }
}