using Discount.Application.Commands;
using Discount.Core.Model;
using Discount.Core.Model.Discounts;
using DIscount.Infrastructure;
using DIscount.Models;
using MediatR;

namespace Discount.Application.Hanlders
{
    public class DiscountCreateCommandHandler
        : IRequestHandler<DiscountCreateCommand, bool>
    {
        private readonly ProductRepository _productRepository;
        private readonly DiscountRepository _discountRepository;

        public DiscountCreateCommandHandler(ProductRepository productRepository,
            DiscountRepository discountRepository)

        {
            this._productRepository = productRepository;
            this._discountRepository = discountRepository;
        }

        public async Task<bool> Handle(DiscountCreateCommand request, 
            CancellationToken cancellationToken)
        {
            ProductModel? productModel
                = this._productRepository.Products
                .Where(e => e.Id == request.discountDTO.ProductID).FirstOrDefault();

            if (productModel == null)
            {
                throw new Exception("Product ID is not Found");
            }

            DiscountModel discountModel = new DiscountModel()
            {
                ProductID = request.discountDTO.ProductID,
                DiscountPercentage = request.discountDTO.DiscountPrecentage,
                DiscountAmount = DiscountAmount(productModel.Price, request.discountDTO.DiscountPrecentage)
            };

            this._discountRepository.Add(discountModel);
            this._discountRepository.SaveChanges();

            return true;
        }

        private decimal DiscountAmount(decimal productCost, int percentage)
        {
            decimal _discountCost;

            _discountCost = (productCost * percentage) / 100;

            return _discountCost;
        }
    }
}
