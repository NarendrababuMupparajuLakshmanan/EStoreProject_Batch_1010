using Basket.Application.Mappers;
using Basket.Application.Queries;
using Basket.Core.DTOs;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers
{
    public class GetBasketByUsernameQueryHandler
        : IRequestHandler<GetBasketByUsernameQuery, BasketCheckOutDTO>
    {
        private readonly IBasketRepository _basketRepository;

        public GetBasketByUsernameQueryHandler(IBasketRepository basketRepository)
        {
            this._basketRepository = basketRepository;
        }

        public async Task<BasketCheckOutDTO> Handle(GetBasketByUsernameQuery request, CancellationToken cancellationToken)
        {
            var basket = await this._basketRepository.GetBasketAsync(request.userName);

            return basket.ToMapBasket();
        }
    }
}
