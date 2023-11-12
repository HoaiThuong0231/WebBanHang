using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebBanHang.Controllers;
using WebBanHang.Models.Entities;
using WebBanHang.Models.HomeModels;

namespace WebsiteBanHang.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IMapper mapper, WebBanHangContext db) : base(mapper, db)
        {
        }
        public async Task<IActionResult> Index()
        {
            var ListCategory = await _db.Category.ToListAsync();
            return View();
        }
        public async Task<IActionResult> ProductCategory(int Id)
        {
            var listProduct = await _db.Product.Where(n => n.CategoryId == Id).ToListAsync();
            return View(listProduct);
        }
    }
}