using Catalog.Application.Commands;
using Catalog.Core.Models.Products;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class DeleteProductCommandHandler
        : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly ProductRepository _productRepository;

        public DeleteProductCommandHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, 
            CancellationToken cancellationToken)
        {
            ProductModel? productModel
               = this._productRepository.Products
                    .Where(e => e.Id == request.Id).FirstOrDefault();

            if (productModel == null)
                throw new Exception("Product Model is not null or Empty");

            this._productRepository.Remove(productModel);
            this._productRepository.SaveChanges();

            return true;

        }
    }
}
