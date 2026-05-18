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

            var res = repo.Create(data); ;
            return res;
        }

        public User Authenticate(LoginDTO obj)
        {
            var res= repo.Authenticate(obj.UserName, obj.Password);
            return res;
        }

        public EditProfileDTO Get(int id)
        {
            var data = repo.Get(id);

            var res = mapper.Map<EditProfileDTO>(data);

            return res;
        }

        public bool Update(EditProfileDTO u)
        {
            var oldData = repo.Get(u.Id);

            var dataa = mapper.Map<User>(u);

            dataa.Role = oldData.Role;
            dataa.Password = oldData.Password;

            var res = repo.Update(dataa);

            return res;
        }
    }
}