using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebShopProject.DAL
{
    public class WebShopContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebShopContext() : base("name=WebShopContext")
        {
        }

        public System.Data.Entity.DbSet<WebShopProject.Models.Movie> Movies { get; set; }
        public System.Data.Entity.DbSet<WebShopProject.Models.Product> Products { get; set; }
        public System.Data.Entity.DbSet<WebShopProject.Models.Format> Formats { get; set; }

        public System.Data.Entity.DbSet<WebShopProject.Models.Customer> Customers { get; set; }
    }
}
