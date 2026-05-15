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
        public User Authenticate(string username, string password)
        {
            var user = (from u in db_data.Users
                        where u.UserName.Equals(username)
                        && u.Password.Equals(password)
                        select u).FirstOrDefault();

            return user;
        }

        public User Get(int id)
        {
            return db_data.Users.Find(id);
        }

        public bool Update(User u)
        {
            var exobj = Get(u.Id);

            db_data.Entry(exobj).CurrentValues.SetValues(u);

            return db_data.SaveChanges() > 0;
        }
    }
}
