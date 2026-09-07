namespace EstoreModel.Models.Products
{
    public class ProductModel
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public string ImageName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public Guid TypeId { get; set; }

        public Guid BrandId { get; set; }

        public decimal Price { get; set; }

        public int GST { get; set; }

        public decimal TotalCost { get; set; }
    }
}
