using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.DTOs.Products;
using Catalog.Core.Models.Products;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductByTypeIdQueryHandler
        : IRequestHandler<GetProductByTypeIdQuery, List<ProductDTO>>
    {
        private readonly ProductRepository _productRepository;
        private readonly BrandRepository _brandRepository;
        private readonly TypeRepository _typeRepository;

        public GetProductByTypeIdQueryHandler(ProductRepository productRepository,
            BrandRepository brandRepository,
            TypeRepository typeRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _typeRepository = typeRepository;
        }


        public Task<List<ProductDTO>> Handle(GetProductByTypeIdQuery request,
            CancellationToken cancellationToken)
        {
            if (request.typeId == Guid.Empty)
            {
                throw new ArgumentException("TypeId cannot be empty.", nameof(request.typeId));
            }

            List<ProductModel> productModels
                = this._productRepository.Products
                .Where(e => e.TypeId == request.typeId).ToList();

            if (productModels == null || !productModels.Any())
            {
                throw new KeyNotFoundException($"No products found for TypeId: {request.typeId}");
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
