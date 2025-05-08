using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTaskLibrary.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string ReleaseDate { get; set; }
        public int AvailableQty { get; set; }
    }
}