using Discount.Application.Mappers;
using Discount.Application.Queries;
using Discount.Core.DTOs;
using Discount.Core.Model.Discounts;
using DIscount.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Discount.Application.Handlers
{
    public class GetDiscountByProductIDHandler
        : IRequestHandler<GetDiscountByProductID, DiscountReadDTO>
    {
        private readonly DiscountRepository _discountRepository;

        public GetDiscountByProductIDHandler(DiscountRepository discountRepository)
        {
            this._discountRepository = discountRepository;
        }

        public async Task<DiscountReadDTO> Handle(GetDiscountByProductID request, 
            CancellationToken cancellationToken)
        {
            DiscountModel? discountModel
                = await this._discountRepository.Discounts
                        .Where(e => e.ProductID == request.productID).FirstOrDefaultAsync();

            return discountModel.ToMapDiscount();
        }
    }
}
