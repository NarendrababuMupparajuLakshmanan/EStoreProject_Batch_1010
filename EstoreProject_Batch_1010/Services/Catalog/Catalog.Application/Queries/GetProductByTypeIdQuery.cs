using Catalog.Core.DTOs.Products;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetProductByTypeIdQuery(Guid typeId)
        : IRequest<List<ProductDTO>>
    {
    }
}
