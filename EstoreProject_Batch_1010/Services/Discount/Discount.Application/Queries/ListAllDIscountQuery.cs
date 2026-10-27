using Discount.Core.DTOs;
using MediatR;

namespace Discount.Application.Queries
{
    public record ListAllDiscountQuery
        : IRequest<List<DiscountReadDTO>>
    {
    }
}
