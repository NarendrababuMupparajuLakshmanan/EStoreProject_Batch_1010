namespace Basket.Core.Models
{
    public class CartInformation
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; init; } = string.Empty;

        public string ProductDescription { get; init; } = string.Empty;

        public string ProductImage { get; init; } = string.Empty;

        public decimal ProductPrice { get; init; }

        public int ProductQuantity { get; init; } = 1;
    }
}
