using Discount.Application.Mappers;
using Discount.Application.Queries;
using Discount.Core.DTOs;
using Discount.Core.Model.Discounts;
using DIscount.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Discount.Application.Handlers
{
    public class ListAllDiscountQueryHandler
        : IRequestHandler<ListAllDiscountQuery, List<DiscountReadDTO>>
    {
        private readonly DiscountRepository _discountRepository;

        public ListAllDiscountQueryHandler(DiscountRepository discountRepository)
        {
            this._discountRepository = discountRepository;
        }

        public async Task<List<DiscountReadDTO>> Handle(ListAllDiscountQuery request, 
            CancellationToken cancellationToken)
        {
            List<DiscountModel> discountModels
                = await this._discountRepository.Discounts.ToListAsync();

            return discountModels.ToMapDiscounts();
        }
    }
}
