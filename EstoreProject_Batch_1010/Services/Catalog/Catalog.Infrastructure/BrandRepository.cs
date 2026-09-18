using Catalog.Core.Models.Brands;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure
{
    public class BrandRepository : DbContext
    {

        public BrandRepository(DbContextOptions<BrandRepository> options)
            : base(options)
        {
            
        }

        public DbSet<BrandModel> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
