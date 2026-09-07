using EstoreModel.Models.Products;

namespace EstoreModel.Services
{
    public interface IProductService
    {
        List<ProductModel> GetAllProducts();
    }
}
