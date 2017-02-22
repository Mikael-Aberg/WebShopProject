namespace WebShopProject.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebShopProject.DAL.WebShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebShopProject.DAL.WebShopContext context)
        {
            var formats = new[]
            {
                new Format { FormatName = "DVD" },
                new Format { FormatName = "Blue-ray" },
                new Format { FormatName = "VHS" }
            };

            context.Formats.AddOrUpdate(x => x.FormatName, formats);
            context.SaveChanges();

            var movies = new[]
            {
                new Movie { Title = "Cashing Checks for Cutsman", Director = "Paca Antonisen", Year = 1908 },
                new Movie { Title = "Marching Against Redcloud", Director = "Morris Adesso", Year = 1911 },
                new Movie { Title = "Slacking with McGee", Director = "Kayin Morris", Year = 1916 },
                new Movie { Title = "Saving Dennis", Director = "Yehudit Muyskens", Year = 1918 },
                new Movie { Title = "Untying a Fuzzy Rabbit", Director = "Viktor Sandoval", Year = 1922 },
                new Movie { Title = "Annoying Forsberg", Director = "Tanya Silva", Year = 1931 },
                new Movie { Title = "Running Against My Wife", Director = "Ridha Novosad", Year = 1950 },
                new Movie { Title = "Surfing with Tennysan", Director = "Sukriye Emerson", Year = 1953 },
                new Movie { Title = "Destroying Carter", Director = "Pyrrhos Plank", Year = 1960 },
                new Movie { Title = "Loving My Rat Bastard of a Brother", Director = "Milenko Nacar", Year = 1963 },
            };

            context.Movies.AddOrUpdate(x => x.Title, movies);
            context.SaveChanges();

            var products = new[]
            {
                new Product { MovieId = movies[0].Id, FormatId = formats[0].Id, Price = 359 },
                new Product { MovieId = movies[1].Id, FormatId = formats[1].Id, Price = 220 },
                new Product { MovieId = movies[2].Id, FormatId = formats[2].Id, Price = 55 },
                new Product { MovieId = movies[3].Id, FormatId = formats[0].Id, Price = 394 },
                new Product { MovieId = movies[4].Id, FormatId = formats[1].Id, Price = 97 },
                new Product { MovieId = movies[5].Id, FormatId = formats[2].Id, Price = 210 },
                new Product { MovieId = movies[6].Id, FormatId = formats[0].Id, Price = 101 },
                new Product { MovieId = movies[7].Id, FormatId = formats[1].Id, Price = 439 },
                new Product { MovieId = movies[8].Id, FormatId = formats[2].Id, Price = 104 },
                new Product { MovieId = movies[9].Id, FormatId = formats[0].Id, Price = 296 },
                new Product { MovieId = movies[0].Id, FormatId = formats[1].Id, Price = 344 },
                new Product { MovieId = movies[1].Id, FormatId = formats[2].Id, Price = 372 },
                new Product { MovieId = movies[2].Id, FormatId = formats[0].Id, Price = 398 },
                new Product { MovieId = movies[3].Id, FormatId = formats[1].Id, Price = 221 },
                new Product { MovieId = movies[4].Id, FormatId = formats[2].Id, Price = 393 },
            };

            context.Products.AddOrUpdate(x => new { x.MovieId, x.FormatId }, products);
            context.SaveChanges();

            var customers = new[]
            {
                new Customer { FirstName = "Ronda", LastName = "Black", Email = "Ronda@gmail.com" },
                new Customer { FirstName = "Owen", LastName = "Allan", Email = "Owen@gmail.com" },
                new Customer { FirstName = "Magdalen", LastName = "Traves", Email = "Magdalen@gmail.com" },
                new Customer { FirstName = "Brande", LastName = "Dean", Email = "Brande@gmail.com" },
                new Customer { FirstName = "Katherina", LastName = "Lindon", Email = "Katherina@gmail.com" },
            };

            context.Customers.AddOrUpdate(x => x.Email, customers);
            context.SaveChanges();
        }
    }
}
