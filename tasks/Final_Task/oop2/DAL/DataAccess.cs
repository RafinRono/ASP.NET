﻿using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        public static IRepo<Product, int, Product> ProductData()
        {
            return new ProductRepo();
        }

        public static IRepo<Order, int, Order> OrderData()
        {
            return new OrderRepo();
        }

        public static IRepo<User, int, User> UserData()
        {
            return new UserRepo();
        }
    }
}
