using Catalog.Core.DTOs.Brands;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetAllBrandQuery(): IRequest<List<BrandDTO>>
    {

    }
}
