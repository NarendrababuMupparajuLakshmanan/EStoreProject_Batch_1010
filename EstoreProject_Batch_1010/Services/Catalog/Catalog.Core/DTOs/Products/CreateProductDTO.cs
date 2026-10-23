using Microsoft.AspNetCore.Http;

namespace Catalog.Core.DTOs.Products
{
    public record CreateProductDTO(
        string ProductName,
        string ProductDescription,
        Guid BrandId,
        Guid TypeId,
        decimal ProductPrice,
        IFormFile uploadImage
    );
}
