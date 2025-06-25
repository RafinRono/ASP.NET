using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ProductRepo: Repo, IRepo<Product, int, Product>
    {
        public Product Create(Product obj)
        {
            db.Products.Add(obj);
            if(db.SaveChanges() > 0) return obj;
            return null;
        }
        public Product Update(Product obj)
        {
            try
            {
                var test = Get(obj.Id);
                //test.Name = obj.Name;
                //test.Price = obj.Price;
                //test.Qty = obj.Qty;
                db.Entry(test).CurrentValues.SetValues(obj);
                if(db.SaveChanges() > 0) return obj;
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
            return db.SaveChanges() > 0;

        }
        public List<Product> Get()
        {
            return db.Products.ToList();
        }
        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public dynamic Confirm(List<Product> cart)
        {
            return cart.ToList();
        }

        public bool BulkInsert(List<Product> products)
        {
            db.Products.AddRange(products);
            return db.SaveChanges() > 0;
        }
    }
}
