using EstoreModel.Models.Types;
using Microsoft.EntityFrameworkCore;

namespace EStoreRepository
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

            //modelBuilder.Entity<TypeModel>().ToTable("Types");

            //modelBuilder.Entity<TypeModel>().HasData(
            //        new TypeModel()
            //        {
            //            Id = Guid.NewGuid(),
            //            Name = "Fridge"
            //        },
            //         new TypeModel()
            //         {
            //             Id = Guid.NewGuid(),
            //             Name = "Washing Machine"
            //         },
            //          new TypeModel()
            //          {
            //              Id = Guid.NewGuid(),
            //              Name = "Mobile"
            //          }


            //    );
        }
    }
}
