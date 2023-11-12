using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebBanHang.Controllers;
using WebBanHang.Models.Entities;
using WebBanHang.Utilities;

namespace WebsiteBanHang.Controllers
{
    [Authorize]
    public class CartController : BaseController
    {
        public CartController(IMapper mapper, WebBanHangContext db) : base(mapper, db)
        {

        }
        public async Task<IActionResult> Index()
        {
            var cart = await _db.VCart.Where(x=>x.UserId==User.GetUserId()).ToListAsync();
            return View(cart);
        }
        public async Task<IActionResult> AddCart()
        {
            var cart = await _db.VCart.Where(x=>x.UserId==User.GetUserId()).ToListAsync();
            return View(cart);
        }
        public async Task<IActionResult> UpdateCart()
        {
            var cart = await _db.VCart.Where(x=>x.UserId==User.GetUserId()).ToListAsync();
            return View(cart);
        }
        public async Task<IActionResult> DeleteCart()
        {
            var cart = await _db.VCart.Where(x=>x.UserId==User.GetUserId()).ToListAsync();
            return View(cart);
        }
    }
}