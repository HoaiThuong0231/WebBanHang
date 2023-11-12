using AutoMapper;
using WebBanHang.Models.Entities;
using WebBanHang.Models.LoginModels;

namespace WebBanHang.Models.Mappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, LoginResponse>();
            CreateMap<RegisterUser, Users>();
        }
    }
}
