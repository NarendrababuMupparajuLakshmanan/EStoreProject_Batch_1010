using Basket.Core.DTOs;
using Basket.Core.Models;

namespace Basket.Application.Mappers
{
    public static class BasketMapper
    {

        public static BasketCheckOutDTO
            ToMapBasket(this BasketCheckOut basketCheckOut)
        {
            BasketCheckOutDTO basketCheckOutDTO = null;
            if (basketCheckOut != null)
            {
                basketCheckOutDTO = new BasketCheckOutDTO(
                        basketCheckOut.UserName,
                        basketCheckOut.CartItems.ToMapCarts());

            }

            return basketCheckOutDTO;
        }


        public static List<CartInformationDTO>
            ToMapCarts(this List<CartInformation> cartInformations)
        {
            List<CartInformationDTO> cartInformationDTOs = null;

            if (cartInformations != null && cartInformations.Count != 0)
            {
                cartInformationDTOs = new List<CartInformationDTO>();

                foreach (CartInformation cartInformation in cartInformations)
                {
                    cartInformationDTOs.Add(cartInformation.ToMapCart());
                }
            }

            return cartInformationDTOs;
        }


        public static CartInformationDTO
            ToMapCart(this CartInformation cartInformation)
        {
            CartInformationDTO cartInformationDTO = null;
            if (cartInformation != null)
            {
                cartInformationDTO = new CartInformationDTO
                    (cartInformation.ProductId,
                    cartInformation.ProductName,
                    cartInformation.ProductDescription,
                    cartInformation.ProductImage,
                    cartInformation.ProductPrice,
                    cartInformation.ProductQuantity);
            }

            return cartInformationDTO;
        }
    }
}
