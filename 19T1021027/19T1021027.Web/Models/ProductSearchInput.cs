using _19T1021027.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021027.Web.Models
{
    public class ProductSearchInput : PaginationSearchInput
    {
        public int CategoryId { get; set; } = 0;
        public int SuplierId { get; set; } = 0;
    }
}