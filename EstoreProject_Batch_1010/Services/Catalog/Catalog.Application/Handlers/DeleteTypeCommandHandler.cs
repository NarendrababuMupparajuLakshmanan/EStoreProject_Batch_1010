using Catalog.Application.Commands;
using Catalog.Core.Models.Types;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class DeleteTypeCommandHandler
        : IRequestHandler<DeleteTypeCommand, bool>
    {
        private readonly TypeRepository _typeRepository;

        public DeleteTypeCommandHandler(TypeRepository typeRepository)
        {
            this._typeRepository = typeRepository;
        }
        public Task<bool> Handle(DeleteTypeCommand request,
            CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                throw new Exception("Type Id is not null or Empty");

            TypeModel? typeModel
                = this._typeRepository.Types
                    .Where(e => e.Id == request.Id).FirstOrDefault();

            if (typeModel == null)
                throw new Exception("Type Model Data is null or Empty");

            this._typeRepository.Remove(typeModel);
            this._typeRepository.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
