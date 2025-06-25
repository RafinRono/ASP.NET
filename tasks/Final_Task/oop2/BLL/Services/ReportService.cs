using DAL;
using DAL.Repos;
using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class ReportService
    {
        public static OrderRepo repo = new OrderRepo();
        public static ReportDTO GetTotalRevenue()
        {
            var orders = DataAccess.OrderData().Get();
            var totalRevenue = orders.Sum(o => o.Total);
            var totalOrders = orders.Count;
            double avg = 0;

            if (totalOrders > 0)
            {
                avg = totalRevenue / (double)totalOrders;
            }

            return new ReportDTO
            {
                TotalRevenue = totalRevenue,
                TotalOrders = totalOrders,
                AverageOrderValue = Math.Round(avg, 2)
            };
        }

        public static List<object> GetTopSellingProducts(int topN = 5)
        {
            var orderDetails = repo.GetDetails();
            var products = DataAccess.ProductData().Get();

            var grouped = orderDetails
                .GroupBy(od => od.ProductID)
                .Select(g => new
                {
                    ProductID = g.Key,
                    QtySold = g.Sum(x => x.Qty)
                })
                .OrderByDescending(x => x.QtySold)
                .Take(topN)
                .ToList();

            return grouped.Join(products, g => g.ProductID, p => p.Id,
                (g, p) => new
                {
                    p.Name,
                    g.QtySold
                }).ToList<object>();
        }

        public static string GetTotalRevenueXml()
        {
            var data = GetTotalRevenue();

            var xml = new XElement("TotalRevenueReport",
                new XElement("TotalRevenue", data.TotalRevenue),
                new XElement("TotalOrders", data.TotalOrders),
                new XElement("AverageOrderValue", data.AverageOrderValue)
            );

            return xml.ToString();
        }

        public static string GetTopSellingProductsXml()
        {
            var products = GetTopSellingProducts(5);

            var xml = new XElement("TopSellingProducts",
                products.Select(p =>
                    new XElement("Product",
                        new XElement("Name", p.GetType().GetProperty("Name").GetValue(p)),
                        new XElement("QtySold", p.GetType().GetProperty("QtySold").GetValue(p))
                    )
                )
            );

            return xml.ToString();
        }
    }
}
