using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderShowDetailsDTO : OrderDTO
    {
        public List<OrderDetailDTO> OrderDetails { get; set; }
        public OrderShowDetailsDTO()
        {
            OrderDetails = new List<OrderDetailDTO>();
        }
    }
}
