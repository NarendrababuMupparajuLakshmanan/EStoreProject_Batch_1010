using EstoreModel.Models.Products;

namespace EstoreModel.Services
{
    public interface IProductService
    {
        List<ProductList> GetAllProducts();

        void CreateProduct(CreateProductModel createProductModel, string ImageFullPath);

        void DeleteProduct(Guid Id, string ImageFullPath);

        UpdateProductModel EditProduct(Guid Id);

        void UpdateProduct(UpdateProductModel updateProductModel, string ImageFullPath);
    }
}
