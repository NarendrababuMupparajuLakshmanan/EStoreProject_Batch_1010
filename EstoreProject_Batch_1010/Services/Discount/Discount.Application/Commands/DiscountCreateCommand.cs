using Discount.Core.DTOs;
using MediatR;

namespace Discount.Application.Commands
{
    public record DiscountCreateCommand(DiscountDTO discountDTO)
        : IRequest<bool>
    {
    }
}
