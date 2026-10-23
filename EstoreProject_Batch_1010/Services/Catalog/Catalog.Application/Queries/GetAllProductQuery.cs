using Catalog.Core.DTOs.Products;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetAllProductQuery()
        : IRequest<List<ProductDTO>>
    {
    }
}
