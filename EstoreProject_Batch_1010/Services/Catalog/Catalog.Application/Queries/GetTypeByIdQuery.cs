using Catalog.Core.DTOs.Types;
using MediatR;

namespace Catalog.Application.Queries
{
    public record GetTypeByIdQuery(Guid Id)
        : IRequest<TypeDTO>
    {
    }
}
