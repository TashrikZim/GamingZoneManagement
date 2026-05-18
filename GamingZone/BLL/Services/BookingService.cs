using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
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



        public bool Create(BookingDTO b)
        {
            var data = mapper.Map<Booking>(b);
            var res = repo.Create(data);
            return res;
        }

        public List<BookingDTO> GetByUser(int userId)
        {
            var data = repo.GetByUser(userId);
            var res = mapper.Map<List<BookingDTO>>(data);
            return res;
        }

        public decimal TotalBookingAmount()
        {
            var res = repo.TotalBookingAmount();

            return res;
        }
    }
}
