using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class UserRepo
    {
        GymManagementDbContext db;

        public UserRepo(GymManagementDbContext db)
        {
            this.db = db;
        }

        public bool Create(User u)
        {
            db.Users.Add(u);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User u)
        {
            var exobj = Get(u.UserId);

            db.Entry(exobj).CurrentValues.SetValues(u);

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Users.Remove(exobj);
            return db.SaveChanges() > 0;
        }




        public User Authenticate(string uname, string pass)
        {
            var user = (from u in db.Users
                        where u.Username.Equals(uname)
                        && u.Password.Equals(pass)
                        select u).SingleOrDefault();

            return user;
        }

        public User Get(string uname)
        {
            var user = (from u in db.Users
                        where u.Username.Equals(uname)
                        select u).SingleOrDefault();

            return user;
        }

    }
}