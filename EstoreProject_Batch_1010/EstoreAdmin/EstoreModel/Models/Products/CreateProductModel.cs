using Microsoft.AspNetCore.Http;

namespace EstoreModel.Models.Products
{
    public class CreateProductModel
    {

        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public Guid BrandId { get; set; }

        public Guid TypeId { get; set; }

        public IFormFile UploadImage { get; set; }

        public int ProductPrice { get; set; }
   
    }
}
