using EstoreModel.Models.Brands;

namespace EstoreModel.Services
{
    public interface IBrandService
    {
        List<BrandModel> ListBrands();

        void DeleteBrand(Guid Id);

        void CreateBrand(CreateBrandModel createBrandModel);
    }
}
