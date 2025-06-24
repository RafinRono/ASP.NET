using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ProductRepo: Repo
    {
        public void Create(Product obj)
        {
            db.Products.Add(obj);
            db.SaveChanges();
        }
        public void Update(Product obj)
        {
            var test = db.Products.Find(obj.Id);
            test.Name = obj.Name;
            test.Price = obj.Price;
            test.Qty = obj.Qty;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var data = db.Products.Find(id);
            //if (data != null)
            //{
            //    db.Products.Remove(data);
            //    db.SaveChanges();
            //}
            //try
            //{
            //    db.Products.Remove(data);
            //    db.SaveChanges();
            //}
            //catch (Exception ex)
            //{

            //}
            db.Products.Remove(data);
            db.SaveChanges();
        }
        public List<Product> Get()
        {
            return db.Products.ToList();
        }
        public Product Get(int id)
        {
            return db.Products.Find(id);
        }
    }
}
