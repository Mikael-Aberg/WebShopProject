using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebShopProject.Models
{
    public class ProductSearchParamaters
    {
        public string Title { get; set; }
        [DisplayName("Format")]
        public int? FormatId { get; set; }
    }
}