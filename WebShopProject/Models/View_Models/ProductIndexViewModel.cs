using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShopProject.Models
{
    public class ProductIndexViewModel
    {
        public List<Product> Products { get; set; }
        public string Sort { get; set; }

        
        public SelectList Formats { get; set; }

        public ProductSearchParamaters OldSearchParams { get; set; }
        public ProductSearchParamaters SearchParams { get; set; }
    }
}