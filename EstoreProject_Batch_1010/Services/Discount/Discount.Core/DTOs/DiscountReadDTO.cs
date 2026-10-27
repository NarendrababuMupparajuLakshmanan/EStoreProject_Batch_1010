namespace Discount.Core.DTOs
{
    public record DiscountReadDTO(
        Guid ProductID,
        int DiscountPrecentage,
        decimal DiscountAmount);
}
