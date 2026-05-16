using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;

namespace BLL
{
    public class MapperConfig
    {
        public static MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, RegisterDTO>().ReverseMap();
            cfg.CreateMap<User,EditProfileDTO>().ReverseMap();
            cfg.CreateMap<GamingSetup,GamingSetupDTO>().ReverseMap();
        });

        public static Mapper GetMapper()
        {
            return new Mapper(config);
        }
    }
}