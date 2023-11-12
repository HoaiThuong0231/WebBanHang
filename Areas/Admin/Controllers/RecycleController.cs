using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebBanHang.Models.Entities;

namespace WebBanHang.Areas.Admin.Controllers
{
    //Chhức năng thùng rác
    public class RecycleController : BaseAdminController
    {
        public RecycleController(IMapper mapper, WebBanHangContext db) : base(mapper, db)
        {
        }

        public async Task<ActionResult> Product()
        {
            var products = await _db.Product.ToListAsync();
            return View(products);
        }
        //
        public async Task<ActionResult> RestoreProduct(int id)
        {
            var product = await _db.Product.FindAsync(id);
            if (product == null || product.IsDelete == false)
            {
                return await Product();
            }
            product.IsDelete = false;
            await _db.SaveChangesAsync();
            return await Product();
        }
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _db.Product.FindAsync(id);
            if (product == null || product.IsDelete == false)
            {
                return await Product();
            }
            _db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _db.SaveChangesAsync();
            return await Product();
        }
    }
}
