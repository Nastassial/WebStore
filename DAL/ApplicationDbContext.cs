using DAL.Models;
using System.Data.Entity;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("StoreDB")
        {
        }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                        .HasMany(s => s.Products)
                        .WithMany(p => p.Stores)
                        .Map(sp =>
                        {
                            sp.MapLeftKey("StoreId");
                            sp.MapRightKey("ProductId");
                            sp.ToTable("StoreProduct");
                        });

            base.OnModelCreating(modelBuilder);
        }
    }
}
