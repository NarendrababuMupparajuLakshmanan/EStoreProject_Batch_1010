using Discount.Core.DTOs;
using MediatR;

namespace Discount.Application.Queries
{
    public record GetDiscountByProductID(Guid productID)
        : IRequest<DiscountReadDTO>
    {
    }
}
