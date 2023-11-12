using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Models.Entities;

namespace WebBanHang.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles ="Admin")]
    public abstract class BaseAdminController : Controller
    {
        public readonly IMapper _mapper;
        
        public readonly WebBanHangContext _db;
        public BaseAdminController(IMapper mapper, WebBanHangContext db)
        {
            _mapper=mapper; 
            _db=db;
        }
    }
}
