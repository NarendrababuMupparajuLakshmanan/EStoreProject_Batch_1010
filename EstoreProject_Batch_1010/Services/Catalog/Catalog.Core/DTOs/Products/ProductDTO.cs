using Catalog.Core.DTOs.Brands;
using Catalog.Core.DTOs.Types;

namespace Catalog.Core.DTOs.Products
{
    public record ProductDTO
    (   Guid Id,
        string ProductName,
        string ProductDescription,
        string ImageName,
        string ImageUrl,
        BrandDTO Brands,
        TypeDTO Types,
        decimal Price,
        int GST,
        decimal TotalCost);
}
