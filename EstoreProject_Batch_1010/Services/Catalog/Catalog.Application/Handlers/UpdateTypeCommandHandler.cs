using Catalog.Application.Commands;
using Catalog.Core.Models.Brands;
using Catalog.Core.Models.Types;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class UpdateTypeCommandHandler
        : IRequestHandler<UpdateTypeCommand, bool>
    {
        private readonly TypeRepository _typeRepository;

        public UpdateTypeCommandHandler(TypeRepository typeRepository)
        {
            this._typeRepository = typeRepository;
        }

        public Task<bool> Handle(UpdateTypeCommand request, 
            CancellationToken cancellationToken)
        {
            TypeModel typeModel
                = new TypeModel()
                {
                    Id = request.UpdateTypeDTO.Id,
                    Name = request.UpdateTypeDTO.Name
                };

            this._typeRepository.Update(typeModel);
            this._typeRepository.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
