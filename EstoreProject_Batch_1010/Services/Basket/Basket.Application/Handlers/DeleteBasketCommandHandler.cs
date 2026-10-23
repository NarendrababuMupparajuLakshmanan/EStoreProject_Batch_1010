using Basket.Application.Commands;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers
{
    public class DeleteBasketCommandHandler
        : IRequestHandler<DeleteBasketCommand, bool>
    {
        private readonly IBasketRepository _basketRepository;

        public DeleteBasketCommandHandler(IBasketRepository basketRepository)
        {
            this._basketRepository = basketRepository;
        }

        public async Task<bool> Handle(DeleteBasketCommand request, 
            CancellationToken cancellationToken)
        {
           await this._basketRepository.DeleteBasketAsync(request.userName);

            return await Task.FromResult(true);
        }
    }
}
