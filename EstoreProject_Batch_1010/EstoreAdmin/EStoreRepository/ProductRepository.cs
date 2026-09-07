using EstoreModel.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace EStoreRepository
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

            modelBuilder.Entity<ProductModel>().ToTable("Products");

            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ProductName).IsRequired();
                entity.Property(e => e.ProductDescription).IsRequired();
                entity.Property(e => e.ImageName).IsRequired();
                entity.Property(e => e.ImageUrl).IsRequired();
                entity.Property(e => e.TypeId).IsRequired();
                entity.Property(e => e.BrandId).IsRequired();
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.GST).IsRequired();
                entity.Property(e => e.TotalCost).IsRequired();
            });
        }
    }
}
