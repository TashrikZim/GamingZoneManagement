using AutoMapper;
using BLL.DTOs;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class BookingService
    {
        BookingRepo repo;
        Mapper mapper;

        public BookingService(BookingRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<GamingSetupDTO> GetAvailableSetups(AvailableSetupDTO s)
        {
            var data = repo.GetAvailableSetups(s.SetupType);

            var res = mapper.Map<List<GamingSetupDTO>>(data);

            return res;
        }
    }
}
