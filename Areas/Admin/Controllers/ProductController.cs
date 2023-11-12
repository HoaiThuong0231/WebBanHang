using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanHang.Models.Entities;
using WebBanHang.Models.HomeModels;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController
    {
        public ProductController(IMapper mapper, WebBanHangContext db) : base(mapper, db)
        {

        }

        public async Task<ActionResult> Index(int page)
        {
            if (page < 1)
                page = 1;
            var products = await _db.Product.Where(x => x.IsDelete == false).OrderBy(e => e.Id).Skip((page - 1) * 10).Take(10).ToListAsync();
            ViewBag.TotalProduct = await _db.Product.CountAsync();
            return View(products);
        }
        public async Task<ActionResult> EditProduct(int id, Product product)
        {
            ViewBag.Categories = await GetCategories();
            if (string.IsNullOrEmpty( product.Name))
            {
                var p = await _db.Product.FindAsync(id);
                return View(p);
            }
            product.Deleted = true;
            product.IsDelete = true;
            _db.Update(product);
            await _db.SaveChangesAsync();
            return await Index(1);
        }
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _db.Product.FindAsync(id);
            bool isExist = await _db.CartProduct.AnyAsync(x => x.ProductId == id);
            if (isExist)
                return Content("<script>alert('Could not delete this product');</script>");
            product.Deleted = true;
            product.IsDelete = true;
            _db.Update(product);
            await _db.SaveChangesAsync();
            return Content("<script>alert('Delete Successfully');</script>");
        }
        public async Task<ActionResult> AddProduct(Product product)
        {
            ViewBag.Categories = await GetCategories();
            if (string.IsNullOrEmpty(product.Name))
            {
                return View();
            }
            _db.Add(product);
            await _db.SaveChangesAsync();
            return await Index(1);
        }

        private async Task<List<Category>> GetCategories()
        {
            var categories = await _db.Category.ToListAsync();
            return categories;
        }
    }
}
