using BLL.DTOs;
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
        public static void Create(ProductDTO st)
        {
            var catRepo = new ProductRepo();
            catRepo.Create(Convert(st));
        }

        public static void Update(ProductDTO st)
        {
            var catRepo = new ProductRepo();
            catRepo.Update(Convert(st));
        }

        public static void Delete(int id)
        {
            var catRepo = new ProductRepo();
            catRepo.Delete(id);
        }

        public static List<ProductDTO> Get()
        {
            var catRepo = new ProductRepo();
            var data = catRepo.Get();

            return Convert(data);
        }

        public static ProductDTO Get(int id)
        {
            var catRepo = new ProductRepo();
            var data = catRepo.Get(id);

            return Convert(data);
        }

        public static ProductDTO Convert(Product data)
        {
            if (data == null) return null;
            else
            {
                ProductDTO st = new ProductDTO()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Price = data.Price,
                    Qty = data.Qty,
                };
                return st;
            }
        }

        public static Product Convert(ProductDTO data)
        {
            if (data == null) return null;
            else
            {
                Product st = new Product()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Price = data.Price,
                    Qty = data.Qty,
                };
                return st;
            } 
        }

        public static List<ProductDTO> Convert(List<Product> data)
        {
            List<ProductDTO> list = new List<ProductDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        public static List<Product> Convert(List<ProductDTO> data)
        {
            List<Product> list = new List<Product>();
            foreach (var item in data)
            {
                list.Add(Convert(item));
            }
            return list;
        }
    }
}
