using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTaskLibrary.DTOs
{
    public class BorrowDTO
    {
        public int Id { get; set; }
        public System.DateTime Time { get; set; }
        public string Status { get; set; }
        public int Qty { get; set; }
        public int CreatedBy { get; set; }
    }
}