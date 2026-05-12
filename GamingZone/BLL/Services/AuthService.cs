using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;

namespace BLL.Services
{
    public class AuthService
    {
        UserRepo repo;
        Mapper mapper;

        public AuthService(UserRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public bool Register(RegisterDTO obj)
        {
            var data = mapper.Map<User>(obj);

            data.Role = "User";

            return repo.Create(data);
        }
    }
}