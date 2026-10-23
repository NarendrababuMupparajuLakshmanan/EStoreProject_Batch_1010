using Catalog.Application.Commands;
using Catalog.Core.Models.Products;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class CreateProductCommandHandler
        : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly ProductRepository _productRepository;

        public CreateProductCommandHandler(ProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public Task<Guid> Handle(CreateProductCommand request, 
            CancellationToken cancellationToken)
        {
            if (request.CreateProductDTO == null)
            {
                throw new ArgumentNullException(nameof(request.CreateProductDTO));
            }


            ProductModel productModel = new ProductModel()
            {
                Id = Guid.NewGuid(),
                ProductName = request.CreateProductDTO.ProductName,
                ProductDescription = request.CreateProductDTO.ProductDescription,
                BrandId = request.CreateProductDTO.BrandId,
                TypeId = request.CreateProductDTO.TypeId,
                Price = request.CreateProductDTO.ProductPrice,
                ImageName = request.CreateProductDTO.uploadImage.FileName,
                ImageUrl = string.Empty, // This should be set to the actual URL after uploading the image
                GST = 18,
                TotalCost = request.CreateProductDTO.ProductPrice + (request.CreateProductDTO.ProductPrice * 18 / 100)
            };

            this._productRepository.Products.Add(productModel);
            this._productRepository.SaveChanges();

            return Task.FromResult(productModel.Id);
        }
    }
}
