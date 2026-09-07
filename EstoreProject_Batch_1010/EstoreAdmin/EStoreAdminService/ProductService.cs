using EstoreModel.Models.Products;
using EstoreModel.Services;
using EStoreRepository;

namespace EStoreAdminService
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public List<ProductModel> GetAllProducts()
        {
          
            List<ProductModel> products = 
                this._productRepository.Products.ToList();

            return products;
        }
    }
}
