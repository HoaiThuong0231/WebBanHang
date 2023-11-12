using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebBanHang.Models.Entities;
using WebBanHang.Models.HomeModels;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IMapper mapper, WebBanHangContext db) : base(mapper, db)
        {

        }
        public async Task<ActionResult> Index(int page)
        {
            if (page < 1)
                page = 1;
            HomeModel home = new HomeModel();
            home.ListProduct = await _db.Product.Where(x => x.IsDelete == false).Include(x => x.Review).OrderBy(e => e.Id).Skip((page - 1) * 10).Take(10).ToListAsync();
            home.ListCategory = await _db.Category.ToListAsync();
            ViewBag.TotalProduct = await _db.Product.CountAsync();
            return View(home);
        }
        [Route("/ProductDetail/{id}/{urlFriendly}")]
        public async Task<ActionResult> Detail(int id, string urlFriendly)
        {
            var product = await _db.Product.FindAsync(id);
            if (product == null)
                return await Index(1);
            return View(product);
        }
    }
}