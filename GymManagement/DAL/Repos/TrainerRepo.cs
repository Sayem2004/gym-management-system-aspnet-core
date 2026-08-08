using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class TrainerRepo
    {
        GymManagementDbContext db;

        public TrainerRepo(GymManagementDbContext db)
        {
            this.db = db;
        }

        public bool Create(Trainer t)
        {
            db.Trainers.Add(t);

            return db.SaveChanges() > 0;
        }

        public List<Trainer> Get()
        {
            return db.Trainers.ToList();
        }

        public Trainer Get(int id)
        {
            return db.Trainers.Find(id);
        }

        public bool Update(Trainer t)
        {
            var exobj = Get(t.TrainerId);

            db.Entry(exobj).CurrentValues.SetValues(t);

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);

            db.Trainers.Remove(exobj);

            return db.SaveChanges() > 0;
        }

      
    }
}
