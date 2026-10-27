using Discount.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace DIscount.Models
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
