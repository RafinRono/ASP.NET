using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserRepo : Repo, IRepo<User, int, User>
    {
        public User Create(User obj)
        {
            db.Users.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
        public User Update(User obj)
        {
            try
            {
                var test = Get(obj.Id);
                //test.Name = obj.Name;
                //test.Price = obj.Price;
                //test.Qty = obj.Qty;
                db.Entry(test).CurrentValues.SetValues(obj);
                if (db.SaveChanges() > 0) return obj;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Delete(int id)
        {
            var data = Get(id);
            db.Users.Remove(data);
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

        public dynamic Confirm(List<Product> test)
        {
            return test;
        }

    }
}

