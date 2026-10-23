using Catalog.Core.DTOs.Types;
using MediatR;

namespace Catalog.Application.Commands
{
    public record UpdateTypeCommand(UpdateTypeDTO UpdateTypeDTO)
        : IRequest<bool>
    {
    }
}
