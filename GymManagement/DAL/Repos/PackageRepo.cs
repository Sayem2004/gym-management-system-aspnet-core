using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class PackageRepo
    {
        GymManagementDbContext db;

        public PackageRepo(GymManagementDbContext db)
        {
            this.db = db;
        }

        public bool Create(Package p)
        {
            db.Packages.Add(p);

            return db.SaveChanges() > 0;
        }

        public List<Package> Get()
        {
            return db.Packages.ToList();
        }

        public Package Get(int id)
        {
            return db.Packages.Find(id);
        }

        public bool Update(Package p)
        {
            var exobj = Get(p.PackageId);
            db.Entry(exobj).CurrentValues.SetValues(p);

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);

            db.Packages.Remove(exobj);

            return db.SaveChanges() > 0;
        }
    }
}
