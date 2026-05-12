using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class UserRepo
    {
        GamingZoneDbContext db_data;

        public UserRepo(GamingZoneDbContext db_data)
        {
            this.db_data = db_data;
        }
        public bool Create(User user) { 
          db_data.Users.Add(user);
            return db_data.SaveChanges() > 0;
        }
    }
}
