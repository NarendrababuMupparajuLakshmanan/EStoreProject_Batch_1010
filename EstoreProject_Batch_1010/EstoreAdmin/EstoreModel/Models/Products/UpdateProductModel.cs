using Microsoft.AspNetCore.Http;

namespace EstoreModel.Models.Products
{
    public class UpdateProductModel
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public Guid BrandId { get; set; }

        public Guid TypeId { get; set; }

        public string ImagePath { get; set; } = string.Empty;

        public IFormFile UploadImage { get; set; }

        public int ProductPrice { get; set; }

    }
}
