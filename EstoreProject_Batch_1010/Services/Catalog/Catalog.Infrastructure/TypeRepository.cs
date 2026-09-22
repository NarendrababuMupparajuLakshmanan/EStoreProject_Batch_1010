using Catalog.Core.Models.Types;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure
{
    public class TypeRepository : DbContext
    {
        public TypeRepository(DbContextOptions<TypeRepository> options)
            : base(options)
        {
            
        }

        public DbSet<TypeModel> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
