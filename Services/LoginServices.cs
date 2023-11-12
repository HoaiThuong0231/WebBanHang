using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using WebBanHang.Models.Entities;
using Microsoft.AspNetCore.Http;
using WebBanHang.Models.CustomModels;
using System.Threading.Tasks;
using WebBanHang.Models.LoginModels;
using WebBanHang.Utilities;
using System;

namespace WebBanHang.Services
{
    public class LoginServices : BaseServices, ILoginServices
    {
        public LoginServices(IHostEnvironment environment, WebBanHangContext db, IHttpContextAccessor httpContextAccessor, IConfiguration config, IMapper mapper) : base(environment, db, httpContextAccessor, config, mapper)
        {
        }

        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        public async Task<ResultCustomModel<LoginResponse>> SignInAsync(LoginRequest login)
        {
            //Xoá khoảng trắng của tên tài khoản và không phân biệt chữ hoa/thường
            login.Username = login.Username.Trim().ToLower();
            login.Password = login.Password.ToMD5();
            Users user = await _db.Users.FirstOrDefaultAsync(x => x.Username == login.Username && x.Password == login.Password);
            if (user == null)
                return new ResultCustomModel<LoginResponse>
                {
                    Code = 400,
                    Data = null,
                    Success = false,
                    Message = "Wrong username or password, please try again."
                };
            else
            {
                LoginResponse data = _mapper.Map<LoginResponse>(user);
                #region Phân quyền
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, data.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, login.Username));
                if (user.IsAdmin == true)
                    identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                else
                    identity.AddClaim(new Claim(ClaimTypes.Role, "User"));
                var principal = new ClaimsPrincipal(identity);
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                    IsPersistent = true,
                };
                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal), authProperties);
                #endregion
                return new ResultCustomModel<LoginResponse>
                {
                    Code = 200,
                    Data = data,
                    Success = true,
                    Message = "Ok"
                };
            }

        }

        public async Task<ResultCustomModel<RegisterUser>> SignUpAsync(RegisterUser userRequest)
        {
            userRequest.Email = userRequest.Email.Trim().ToLower();
            userRequest.Username = userRequest.Username.Trim().ToLower();
            userRequest.Password = userRequest.Password.ToMD5();
            var userExist = await _db.Users.FirstOrDefaultAsync(x => x.Email == userRequest.Email || x.Username == userRequest.Username);
            if (userExist != null)
            {
                string msgError = string.Empty;
                if (userExist.Email == userRequest.Email)
                    msgError = "This email is existen!";
                else
                    msgError = "This username is existen!";
                return new ResultCustomModel<RegisterUser>
                {
                    Code = 400,
                    Data = userRequest,
                    Success = false,
                    Message = ""
                };
            }
            Users user = _mapper.Map<Users>(userRequest);
            _db.Add(user);
            int save = await _db.SaveChangesAsync();
            if (save > 0)
                return new ResultCustomModel<RegisterUser>
                {
                    Code = 200,
                    Data = userRequest,
                    Success = true,
                    Message = "Create account successfully!"
                };
            return new ResultCustomModel<RegisterUser>
            {
                Code = 400,
                Data = userRequest,
                Success = false,
                Message = "Can't save to Database!"
            };
        }
    }

}
public interface ILoginServices
{
    Task<ResultCustomModel<LoginResponse>> SignInAsync(LoginRequest login);
    Task<ResultCustomModel<RegisterUser>> SignUpAsync(RegisterUser userRequest);
    Task SignOutAsync();
}
