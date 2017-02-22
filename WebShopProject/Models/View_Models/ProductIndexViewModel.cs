using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopProject.Models
{
    public class ProductIndexViewModel
    {
        public List<Product> Products { get; set; }
        public string Sort { get; set; }
        public ProductSearchParamaters OldSearchParams { get; set; }
        public ProductSearchParamaters SearchParams { get; set; }
    }
}