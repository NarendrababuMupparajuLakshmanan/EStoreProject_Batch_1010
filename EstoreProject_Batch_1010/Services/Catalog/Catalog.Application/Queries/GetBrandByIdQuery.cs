using Catalog.Core.DTOs.Brands;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetBrandByIdQuery(Guid Id)
        : IRequest<BrandDTO>
    {
    }
}
