using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class OrderRepo: Repo, IRepo<Order, int, Order>
    {
        public Order Create(Order obj)
        {
            db.Orders.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
        public Order Update(Order obj)
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
            db.Orders.Remove(data);
            return db.SaveChanges() > 0;
        }
        public List<Order> Get()
        {
            return db.Orders.ToList();
        }

        public List<OrderDetail> GetDetails()
        {
            return db.OrderDetails.ToList();
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public Order Approve(int id)
        {
            var data = Get(id);
            data.Status = "Approved";
            db.SaveChanges();
            return data;
        }

        public Order Reject(int id)
        {
            var data = Get(id);
            data.Status = "Rejected";
            db.SaveChanges();
            return data;
        }

        public dynamic Confirm(List<Product> cart)
        {
            var order = new Order()
            {
                Status = "Pending",
                Total = cart.Sum(p => p.Qty * p.Price),
                UserID = 3
            };
            db.Orders.Add(order);
            db.SaveChanges();

            foreach (var p in cart)
            {
                var od = new OrderDetail()
                {
                    ProductID = p.Id,
                    Qty = p.Qty,
                    Price = p.Price,
                    OrderID = order.Id
                };
                db.OrderDetails.Add(od);

                var product = db.Products.FirstOrDefault(x => x.Id == p.Id);
                if (product != null)
                {
                    if (product.Qty >= p.Qty)
                    {
                        product.Qty -= p.Qty;
                    }
                    else
                    {
                        throw new InvalidOperationException("Error");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Error");
                }
            }

            return db.SaveChanges() > 0;
        }
    }
}
