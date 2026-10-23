using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.DTOs.Products;
using Catalog.Core.Models.Products;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllProductQueryHandler
        : IRequestHandler<GetAllProductQuery, List<ProductDTO>>
    {
        private readonly ProductRepository _productRepository;
        private readonly BrandRepository _brandRepository;
        private readonly TypeRepository _typeRepository;

        public GetAllProductQueryHandler(ProductRepository productRepository,
            BrandRepository brandRepository,
            TypeRepository typeRepository)
        {
            this._productRepository = productRepository;
            this._brandRepository = brandRepository;
            this._typeRepository = typeRepository;
        }


        public Task<List<ProductDTO>> Handle(GetAllProductQuery request, 
            CancellationToken cancellationToken)
        {
            List<ProductModel> productModels
                = this._productRepository.Products.ToList();

            if (productModels.Count == 0)
            {
                throw new Exception("No products found.");
            }

            List<ProductListModel> productListModels = new List<ProductListModel>();

            foreach (var product in productModels)
            {
                productListModels.Add(new ProductListModel
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ImageName = product.ImageName,
                    ImageUrl = product.ImageUrl,
                    Types = this._typeRepository.Types.Where(e => e.Id == product.TypeId).FirstOrDefault(),
                    Brands = this._brandRepository.Brands.Where(b => b.Id == product.BrandId).FirstOrDefault(),
                    Price = product.Price,
                    GST = product.GST,
                    TotalCost = product.TotalCost
                });

            }

            return Task.FromResult(productListModels.ToProductListDTO());

        }
    }
}
