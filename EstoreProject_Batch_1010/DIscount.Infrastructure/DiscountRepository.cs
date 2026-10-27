using Discount.Core.Model.Discounts;
using Microsoft.EntityFrameworkCore;

namespace DIscount.Infrastructure
{
    public class DiscountRepository : DbContext
    {


        public DiscountRepository(DbContextOptions<DiscountRepository> options)
            : base(options)
        {
            
        }

        public DbSet<DiscountModel> Discounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DiscountModel>().ToTable("Discount");

            modelBuilder.Entity<DiscountModel>().HasKey("ProductID");
        }
    }
}
