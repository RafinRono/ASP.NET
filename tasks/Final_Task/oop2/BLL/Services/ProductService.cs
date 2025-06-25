using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
            });
            return new Mapper(config);
        }

        public static dynamic Create(ProductDTO st)
        {
            var data = GetMapper().Map<Product>(st);
            return DataAccess.ProductData().Create(data);
            //return catRepo.Create(Convert(st));
        }

        public static dynamic Update(ProductDTO st)
        {
            var data = GetMapper().Map<Product>(st);
            return DataAccess.ProductData().Update(data);
            //return catRepo.Update(Convert(st));
        }

        public static dynamic Delete(int id)
        {
            return DataAccess.ProductData().Delete(id);
            //return catRepo.Delete(id);
        }

        public static List<ProductDTO> Get()
        {
            var data = DataAccess.ProductData().Get();

            return GetMapper().Map<List<ProductDTO>>(data);

        }

        public static ProductDTO Get(int id)
        {
            var data = DataAccess.ProductData().Get(id);
            return GetMapper().Map<ProductDTO>(data);
        }

        //public static ProductDTO Convert(Product data)
        //{
        //    if (data == null) return null;
        //    else
        //    {
        //        ProductDTO st = new ProductDTO()
        //        {
        //            Id = data.Id,
        //            Name = data.Name,
        //            Price = data.Price,
        //            Qty = data.Qty,
        //        };
        //        return st;
        //    }
        //}

        //public static Product Convert(ProductDTO data)
        //{
        //    if (data == null) return null;
        //    else
        //    {
        //        Product st = new Product()
        //        {
        //            Id = data.Id,
        //            Name = data.Name,
        //            Price = data.Price,
        //            Qty = data.Qty,
        //        };
        //        return st;
        //    } 
        //}

        //public static List<ProductDTO> Convert(List<Product> data)
        //{
        //    List<ProductDTO> list = new List<ProductDTO>();
        //    foreach (var item in data)
        //    {
        //        list.Add(Convert(item));
        //    }
        //    return list;
        //}

        //public static List<Product> Convert(List<ProductDTO> data)
        //{
        //    List<Product> list = new List<Product>();
        //    foreach (var item in data)
        //    {
        //        list.Add(Convert(item));
        //    }
        //    return list;
        //}
    }
}
