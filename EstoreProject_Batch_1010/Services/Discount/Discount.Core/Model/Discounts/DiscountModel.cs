namespace Discount.Core.Model.Discounts
{
    public class DiscountModel
    {
        public Guid ProductID { get; set; }

        public int DiscountPercentage { get; set; }

        public decimal DiscountAmount { get; set; }
    }
}
