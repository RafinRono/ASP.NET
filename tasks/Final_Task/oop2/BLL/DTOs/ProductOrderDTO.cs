using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductOrderDTO : ProductDTO
    {
        public List<OrderDetailDTO> OrderDetails { get; set; }
        public ProductOrderDTO()
        {
            OrderDetails = new List<OrderDetailDTO>();
        }

    }
}
