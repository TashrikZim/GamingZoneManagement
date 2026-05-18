using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class BookingRepo
    {
        GamingZoneDbContext db_data;

        public BookingRepo(GamingZoneDbContext db_data)
        {
            this.db_data = db_data;
        }

        public List<GamingSetup> GetAvailableSetups(string setupType)
        {
            var data = (from g in db_data.GamingSetups
                        where g.SetupType.Equals(setupType)
                        && g.Status.Equals("Available")
                        select g).ToList();

            return data;
        }

        public bool Create(Booking b) {
            db_data.Bookings.Add(b);
            return db_data.SaveChanges() > 0;
        }

        public List<Booking> GetByUser(int userId)
        {
            var data = (from b in db_data.Bookings
                        where b.UserId == userId
                        select b).ToList();

            return data;
        }

        public decimal TotalBookingAmount()
        {
            var total = db_data.Bookings.Sum(b => b.TotalAmount);

            return total;
        }
    }
}
