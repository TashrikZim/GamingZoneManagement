using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class GamingSetupService
    {

        GamingSetupRepo repo;
        Mapper mapper;

        public GamingSetupService(GamingSetupRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }
        public List<GamingSetupDTO> Get()
        {

            var data=repo.Get();
            var res = mapper.Map<List<GamingSetupDTO>>(data);
            return res;
        }
        public GamingSetupDTO Get(int id)
        {
            var data =repo.Get(id);
            var res =mapper.Map<GamingSetupDTO>(data);
            return res;
        }
        public bool Create(GamingSetupDTO g)
        {
            var dataa = mapper.Map<GamingSetup>(g);
            var res = repo.Create(dataa);
            return res;
        }

        public bool Update(GamingSetupDTO g)
        {
            var dataa = mapper.Map<GamingSetup>(g);
            var res = repo.Update(dataa);
            return res;
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

    }
}
