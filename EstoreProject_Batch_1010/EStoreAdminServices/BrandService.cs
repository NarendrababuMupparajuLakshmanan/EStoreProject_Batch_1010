using EstoreModel.Models.Brands;
using EstoreModel.Services;

namespace EStoreAdminServices
{
    public class BrandService : IBrandService
    {
        public List<BrandModel> ListBrands()
        {
            List<BrandModel> brandModels = new List<BrandModel>();

            brandModels.Add(new BrandModel()
            {
                Id = Guid.NewGuid(),
                Name = "Samsung"
            });

            brandModels.Add(new BrandModel()
            {
                Id = Guid.NewGuid(),
                Name = "Vivo"
            });

            brandModels.Add(new BrandModel()
            {
                Id = Guid.NewGuid(),
                Name = "Reliance"
            });

            return brandModels;
        }

        public void CreateBrand()
        {
            Console.WriteLine("Create Brand");
        }
    }
}
