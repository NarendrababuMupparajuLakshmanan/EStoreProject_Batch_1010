using Catalog.Core.DTOs.Products;
using MediatR;

namespace Catalog.Application.Commands
{
    public record CreateProductCommand(CreateProductDTO CreateProductDTO)
        : IRequest<Guid>
    {
    }
}
