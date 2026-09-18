using MediatR;

namespace Catalog.Application.Commands
{
    public record CreateBrandCommand(string Name)
        : IRequest<Guid>
    {
    }
}
