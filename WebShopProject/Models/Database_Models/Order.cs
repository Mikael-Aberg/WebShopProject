using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopProject.Models
{
    public class Order
    {
        public Order() { Created = DateTime.Today; } 

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual Customer Customer { get; set; }
    }
}