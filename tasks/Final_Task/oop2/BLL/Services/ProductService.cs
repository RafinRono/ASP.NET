using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.IO;
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
                cfg.CreateMap<OrderDetail, OrderDetailDTO>();
                cfg.CreateMap<OrderDetailDTO, OrderDetail>();
            });
            return new Mapper(config);
        }
        public static ProductRepo repo = new ProductRepo();

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

        public static ProductOrderDTO GetWithOrders(int id)
        {
            var data = DataAccess.ProductData().Get(id);
            var cfg = new MapperConfiguration(C =>
            {
                C.CreateMap<Product, ProductOrderDTO>();
                C.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductOrderDTO>(data);
            return mapped;

            //return GetMapper().Map<ProductOrderDTO>(data);

        }

        public static bool ImportCsv(Stream csvStream)
        {
            var products = new List<ProductDTO>();

            using (var reader = new StreamReader(csvStream))
            {
                bool isFirstRow = true;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (isFirstRow) { isFirstRow = false; continue; }

                    var parts = line.Split(',');

                    if (parts.Length < 3)
                        continue;

                    try
                    {
                        var dto = new ProductDTO
                        {
                            Name = parts[0].Trim(),
                            Price = double.Parse(parts[1]),
                            Qty = int.Parse(parts[2])
                        };

                        if (dto.Price <= 0 || dto.Qty < 0)
                            continue;

                        products.Add(dto);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            var mapper = GetMapper(); 
            var entities = products.Select(p => mapper.Map<Product>(p)).ToList();

            return repo.BulkInsert(entities);
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
