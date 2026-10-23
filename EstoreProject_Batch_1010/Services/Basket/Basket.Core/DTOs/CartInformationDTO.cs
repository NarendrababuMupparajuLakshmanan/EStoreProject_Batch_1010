namespace Basket.Core.DTOs
{
    public record CartInformationDTO(
        Guid ProductID,
        string ProductName,
        string ProductDescription,
        string ProductImage,
        decimal ProductPrice,
        int ProductQuantity);
    
}
