using Basket.Core.DTOs;
using MediatR;

namespace Basket.Application.Queries
{
    public record GetBasketByUsernameQuery(string userName)
        : IRequest<BasketCheckOutDTO>
    {
    }
}
