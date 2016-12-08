namespace Inventory.Migrations
{
    using Models.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Inventory.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Inventory.Models.ApplicationDbContext";
        }

        protected override void Seed(Inventory.Models.ApplicationDbContext context)
        {
            context.Books.AddOrUpdate(b => b.Title, new BookModel[]
            {
                new BookModel
                {
                    Title = "Narnia",
                    Description = "A cold winter",
                    Rating = "10"
                },
                new BookModel
                {
                    Title = "Narnia",
                    Description = "A cold winter",
                    Rating = "10"
                },
                new BookModel
                {
                    Title = "Narnia",
                    Description = "A cold winter",
                    Rating = "10"
                },
                new BookModel
                {
                    Title = "Narnia",
                    Description = "A cold winter",
                    Rating = "10"
                },
                new BookModel
                {
                    Title = "Narnia",
                    Description = "A cold winter",
                    Rating = "10"
                },
                new BookModel
                {
                    Title = "Narnia",
                    Description = "A cold winter",
                    Rating = "10"
                },
                new BookModel
                {
                    Title = "Narnia",
                    Description = "A cold winter",
                    Rating = "10"
                }
            });
            context.SaveChanges();
        }
    }
}
