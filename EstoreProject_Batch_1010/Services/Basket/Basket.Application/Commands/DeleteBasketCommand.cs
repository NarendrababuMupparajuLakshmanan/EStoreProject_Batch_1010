using MediatR;

namespace Basket.Application.Commands
{
    public record DeleteBasketCommand(string userName)
        : IRequest<bool>
    {
    }
}
