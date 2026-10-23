using Catalog.Application.Commands;
using Catalog.Core.Models.Types;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class CreateTypeCommandHandler
        : IRequestHandler<CreateTypeCommand, bool>
    {
        private readonly TypeRepository _typeRepository;

        public CreateTypeCommandHandler(TypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public Task<bool> Handle(CreateTypeCommand request, 
            CancellationToken cancellationToken)
        {
            TypeModel typeModel = new TypeModel()
            {
                Id = Guid.NewGuid(),
                Name = request.CreateTypeDTO.Name
            };

            this._typeRepository.Add(typeModel);
            this._typeRepository.SaveChanges();

            return Task.FromResult(true);

        }
    }
}
