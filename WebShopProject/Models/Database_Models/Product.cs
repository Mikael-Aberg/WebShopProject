using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace WebShopProject.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        public int FormatId { get; set; }
        public int Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual Format Format { get; set; }
        public virtual Movie Movie { get; set; }
    }
}