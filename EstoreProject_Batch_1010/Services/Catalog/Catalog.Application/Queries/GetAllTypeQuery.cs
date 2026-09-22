using MediatR;
using Catalog.Core.DTOs.Types;

namespace Catalog.Application.Queries
{
    public record GetAllTypeQuery
         : IRequest<List<TypeDTO>>
    {
    }
}
