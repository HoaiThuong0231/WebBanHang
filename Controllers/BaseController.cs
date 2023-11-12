using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Models.Entities;

namespace WebBanHang.Controllers
{
    //[Authorize(Roles ="Admin,User")]
    public abstract class BaseController : Controller
    {
        public readonly IMapper _mapper;
        
        public readonly WebBanHangContext _db;
        public BaseController(IMapper mapper, WebBanHangContext db)
        {
            _mapper=mapper; 
            _db=db;
        }
    }
}
