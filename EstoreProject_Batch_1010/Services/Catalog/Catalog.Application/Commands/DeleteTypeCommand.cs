using MediatR;

namespace Catalog.Application.Commands
{
    public record DeleteTypeCommand(Guid Id)
        : IRequest<bool>
    {

    }
}
