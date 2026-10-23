namespace Basket.Core.DTOs
{
    public record BasketCheckOutDTO(
        string userName,
        List<CartInformationDTO> CartDetails
        );
}
