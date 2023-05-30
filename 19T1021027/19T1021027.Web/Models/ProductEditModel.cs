﻿using _19T1021027.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _19T1021027.Web.Models
{
    public class ProductEditModel 
    {
        public Product Data { get; set; }
        public List<ProductAttribute> Attributes { get; set; }
        public List<ProductPhoto> Photos { get; set; }
    }
}