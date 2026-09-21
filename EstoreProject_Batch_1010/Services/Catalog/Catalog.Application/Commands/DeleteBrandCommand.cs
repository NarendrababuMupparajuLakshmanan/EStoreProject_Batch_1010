using MediatR;

namespace Catalog.Application.Commands
{
    public record DeleteBrandCommand(Guid Id)
        : IRequest<bool>
    {
    }
}
