using Catalog.Core.DTOs.Products;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetProductByBrandIdQuery(Guid brandId)
        : IRequest<List<ProductDTO>>
    {
    }
}
