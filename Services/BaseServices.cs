using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using WebBanHang.Models.Entities;

namespace WebBanHang.Services
{
    public class BaseServices
    {
        public readonly IHostEnvironment _environment;
        public readonly WebBanHangContext _db;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IConfiguration _config;
        public readonly IMapper _mapper;
        public BaseServices(IHostEnvironment environment,
                            WebBanHangContext db,
                            IHttpContextAccessor httpContextAccessor,
                            IConfiguration config,
                            IMapper mapper)
        {
            _environment = environment;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _config = config;
            _mapper = mapper;
        }
    }
}
