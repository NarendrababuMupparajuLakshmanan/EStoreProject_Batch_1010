using MediatR;

namespace Discount.Application.Commands
{
    public record DeleteDiscountByProductIDCommand(Guid productID)
        : IRequest<bool>
    {
    }
}
