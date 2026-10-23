using Catalog.Application.Queries;
using Catalog.Core.DTOs.Products;
using Catalog.Core.Models.Products;
using Catalog.Application.Mappers;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductByBrandIdQueryHandler
        : IRequestHandler<GetProductByBrandIdQuery, List<ProductDTO>>
    {
        private readonly ProductRepository _productRepository;
        private readonly BrandRepository _brandRepository;
        private readonly TypeRepository _typeRepository;

        public GetProductByBrandIdQueryHandler(ProductRepository productRepository,
            BrandRepository brandRepository,
            TypeRepository typeRepository)
        {
            this._productRepository = productRepository;
            this._brandRepository = brandRepository;
            this._typeRepository = typeRepository;
        }
        public Task<List<ProductDTO>> Handle(GetProductByBrandIdQuery request,
            CancellationToken cancellationToken)
        {
            if (request.brandId == Guid.Empty)
            {
                throw new ArgumentException("BrandId cannot be empty.", nameof(request.brandId));
            }

            // Simulate fetching products by brandId from a data source
            List<ProductModel> productModels
                = this._productRepository.Products.
                Where(p => p.BrandId == request.brandId).ToList(); 
            
            if (productModels == null || !productModels.Any())
            {
                throw new KeyNotFoundException($"No products found for BrandId: {request.brandId}");
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
                    Types = this._typeRepository.Types.Where(t => t.Id == product.TypeId).FirstOrDefault(),
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
