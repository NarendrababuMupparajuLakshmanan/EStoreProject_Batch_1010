using Catalog.Core.DTOs.Brands;
using MediatR;

namespace Catalog.Application.Commands
{
    public record UpdateBrandCommand(UpdateBrandDTO updateBrandDTO)
        : IRequest<bool>
    {
    }
}
