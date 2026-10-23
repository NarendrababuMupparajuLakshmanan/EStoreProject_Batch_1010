using Catalog.Core.DTOs.Types;
using MediatR;

namespace Catalog.Application.Commands
{
    public record CreateTypeCommand(CreateTypeDTO CreateTypeDTO)
        : IRequest<bool>
    {
    }
}

