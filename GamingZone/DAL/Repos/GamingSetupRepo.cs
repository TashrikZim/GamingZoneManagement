using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class GamingSetupRepo
    {
        GamingZoneDbContext data;
        public GamingSetupRepo(GamingZoneDbContext data) { 
        this.data = data;
        }

        public bool Create(GamingSetup g)
        {
            data.GamingSetups.Add(g);
            return data.SaveChanges() > 0;
        }
        public List<GamingSetup> Get()
        {
            return data.GamingSetups.ToList();
        }


        public GamingSetup Get(int id)
        {

            return data.GamingSetups.Find(id);
        }

        public bool Update(GamingSetup g) { 
        
        var exobj=Get(g.Id);
            data.Entry(exobj).CurrentValues.SetValues(g);
            return data.SaveChanges() > 0;
        }

        public bool Delete(int id) {

            var exobj = Get(id);
            data.Remove(exobj);
            return data.SaveChanges() > 0;  
        
        }
    }
}
