using Basket.Core.Models;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Infrastructure
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _distributedCache;

        public BasketRepository(IDistributedCache distributedCache)
        {
            this._distributedCache = distributedCache;
        }

        public async Task<bool> DeleteBasketAsync(string userName)
        {
            await this._distributedCache.RemoveAsync(userName);

            return true;
        }

        public async Task<BasketCheckOut> GetBasketAsync(string userName)
        {
            var basket = await this._distributedCache.GetStringAsync(userName);

            if (string.IsNullOrEmpty(basket))
            {
                return null;
            }

            var basketCheckOut = JsonConvert.DeserializeObject<BasketCheckOut>(basket);
            return basketCheckOut;


        }

        public async Task<BasketCheckOut> UpdateBasketAsync(BasketCheckOut basketCheckOut)
        {
            await this._distributedCache.SetStringAsync(basketCheckOut.UserName,
                    JsonConvert.SerializeObject(basketCheckOut));

            return await GetBasketAsync(basketCheckOut.UserName);
        }
    }
}
