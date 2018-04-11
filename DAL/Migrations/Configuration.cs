namespace DAL.Migrations
{
    using DAL.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.ApplicationDbContext context)
        {
            var product1 = new Product()
            {
                Name = "Product1",
                Description = "Descr1"
            };
            var product2 = new Product()
            {
                Name = "Product2",
                Description = "Descr2"
            };
            var product3 = new Product()
            {
                Name = "Product3",
                Description = "Descr3"
            };
            var product4 = new Product()
            {
                Name = "Product4",
                Description = "Descr4"
            };
            var product5 = new Product()
            {
                Name = "Product5",
                Description = "Descr5"
            };
            context.Products.AddRange(new List<Product>() { product1, product2, product3, product4, product5 });
            context.SaveChanges();

            var store1 = new Store()
            {
                Name = "Mila",
                Address = "Address Mila",
                WorkingTime = "Monday - Friday 8.00 - 21.00",
                Products = new List<Product>()
            };
            var store2 = new Store()
            {
                Name = "5 Element",
                Address = "Address 5 Element",
                WorkingTime = "Monday - Friday 8.00 - 21.00",
                Products = new List<Product>()
            };
            var store3 = new Store()
            {
                Name = "Sosedi",
                Address = "Address Sosedi",
                WorkingTime = "Monday - Friday 8.00 - 21.00",
                Products = new List<Product>()
            };
            context.Stores.AddRange(new List<Store> { store1, store2, store3 });
            context.SaveChanges();
            store1.Products.Add(product1);
            store1.Products.Add(product3);
            store2.Products.Add(product2);
            store3.Products.Add(product4);
            store3.Products.Add(product5);
            store3.Products.Add(product1);
            context.SaveChanges();
        }
    }
}
