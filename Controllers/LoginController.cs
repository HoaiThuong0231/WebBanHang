using WebBanHang.Models.LoginModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebBanHang.Utilities;
using System.Threading.Tasks;
using WebBanHang.Models.CustomModels;
using WebBanHang.Services;
using WebBanHang.Models.HomeModels;
using WebBanHang.Models.Entities;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace WebBanHang.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ILoginServices _loginServices;
        private readonly WebBanHangContext _db;
        public LoginController(ILoginServices loginServices, WebBanHangContext db)
        {
            _loginServices = loginServices;
            _db = db;
        }
        public async Task<ActionResult> Index(LoginRequest loginRequest)
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }
            if (!ModelState.IsValid)
                return View();
            var loginResult = await _loginServices.SignInAsync(loginRequest);
            return View(loginResult);
        }
        [Route("/Register")]
        public async Task<ActionResult> Register(RegisterUser user)
        {
            if (!ModelState.IsValid)
            {
                return View(new ResultCustomModel<RegisterUser>
                {
                    Code = 0,
                    Data = user,
                    Success = false,
                    Message = ""
                });
            }
            var result = await _loginServices.SignUpAsync(user);
            if (result.Success)
                return await Index(null);
            return View(result);
        }
        [Route("/Logout")]
        public async Task<ActionResult> Logout()
        {
            await _loginServices.SignOutAsync();
            return await Index(null);
        }
    }
}
