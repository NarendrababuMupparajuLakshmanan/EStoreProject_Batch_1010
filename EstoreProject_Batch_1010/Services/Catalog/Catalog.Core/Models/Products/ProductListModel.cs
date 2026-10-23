using Catalog.Core.Models.Brands;
using Catalog.Core.Models.Types;

namespace Catalog.Core.Models.Products
{
    public class ProductListModel
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public string ImageName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public TypeModel? Types { get; set; }

        public BrandModel? Brands { get; set; }

        public decimal Price { get; set; }

        public int GST { get; set; }

        public decimal TotalCost { get; set; }

        public static object ToProductListDTO()
        {
            throw new NotImplementedException();
        }
    }
}
