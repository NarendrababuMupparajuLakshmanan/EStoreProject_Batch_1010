using Basket.Core.Models;

namespace Basket.Core.Repositories
{
    public interface IBasketRepository
    {

        Task<BasketCheckOut> GetBasketAsync(string userName);

        Task<BasketCheckOut> UpdateBasketAsync(BasketCheckOut basketCheckOut);

        Task<bool> DeleteBasketAsync(string userName);
    }
}
