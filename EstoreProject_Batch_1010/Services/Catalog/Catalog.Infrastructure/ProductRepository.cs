using Catalog.Core.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure
{
    public class ProductRepository : DbContext
    {
        public ProductRepository(DbContextOptions<ProductRepository> options)
            : base(options)
        {
            
        }

        public DbSet<ProductModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
