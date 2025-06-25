using BLL.DTOs;
using DAL.EF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using AutoMapper;

namespace BLL.Services
{
    public class OrderService
    {
        public static List<ProductDTO> cart = new List<ProductDTO>();

        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<Order, OrderDTO>();
            });
            return new Mapper(config);
        }

        public static dynamic Add(ProductDTO st)
        {
            var exs = cart.FirstOrDefault(p => p.Id == st.Id);

            if (exs != null)
            {
                exs.Qty += 1;
            }
            else
            {
                st.Qty = 1;
                cart.Add(st);
            }

            return cart;
        }

        public static List<ProductDTO> ShowCart()
        {
            return cart;
        }

        public static dynamic Remove(ProductDTO st)
        {
            var item = cart.FirstOrDefault(p => p.Id == st.Id);

            if (item != null)
            {
                cart.Remove(item);
            }

            return cart;
        }

        public static dynamic Confirm()
        {
            var data = GetMapper().Map<List<Product>>(cart);
            return DataAccess.OrderData().Confirm(data);
        }

        public static void Clear()
        {
            cart.Clear();
        }

        public static List<OrderDTO> Get()
        {
            var data = DataAccess.OrderData().Get();

            return GetMapper().Map<List<OrderDTO>>(data);
        }
    }
}
