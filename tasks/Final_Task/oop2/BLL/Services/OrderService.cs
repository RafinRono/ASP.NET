using BLL.DTOs;
using DAL.EF;
using DAL.Repos;
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
        public static OrderRepo repo = new OrderRepo();

        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderDetail, OrderDetailDTO>();
                cfg.CreateMap<OrderDetailDTO, OrderDetail>();
            });
            return new Mapper(config);
        }

        public static dynamic Add(ProductDTO st)
        {
            var exs = cart.FirstOrDefault(p => p.Id == st.Id);
            var max = (DataAccess.ProductData().Get(st.Id)).Qty;

            if (exs != null)
            {
                if (exs.Qty < max)
                {
                    exs.Qty += 1;
                }
                else
                {
                    throw new InvalidOperationException($"Maximum available quantity ({max}) reached.");
                }
            }
            else
            {
                if (max > 0)
                {
                    st.Qty = 1;
                    cart.Add(st);
                }
                else
                {
                    throw new InvalidOperationException($"Maximum available quantity ({max}) reached.");
                }
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

        public static List<OrderDetailDTO> GetDetails()
        {
            var data = repo.GetDetails();

            return GetMapper().Map<List<OrderDetailDTO>>(data);
        }

        public static OrderDTO Approve(int id)
        {
            var data = repo.Approve(id);

            return GetMapper().Map<OrderDTO>(data);
        }

        public static OrderDTO Reject(int id)
        {
            var data = repo.Reject(id);

            return GetMapper().Map<OrderDTO>(data);
        }

        public static OrderShowDetailsDTO GetOrders(int id)
        {
            var data = DataAccess.OrderData().Get(id);
            var cfg = new MapperConfiguration(C =>
            {
                C.CreateMap<Order, OrderShowDetailsDTO>();
                C.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderShowDetailsDTO>(data);
            return mapped;

            //return GetMapper().Map<ProductOrderDTO>(data);

        }
    }
}
