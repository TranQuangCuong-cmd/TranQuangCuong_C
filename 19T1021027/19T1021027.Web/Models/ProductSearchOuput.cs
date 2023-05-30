using _19T1021027.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021027.Web.Models
{
    public class ProductSearchOuput : PaginationSearchOutput
    {
        public List<Product> Data { get; set; }
        public int CategoryId { get; set; }
        public int SuplierId { get; set; }
    }
}