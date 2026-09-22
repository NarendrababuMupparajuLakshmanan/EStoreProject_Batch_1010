using Catalog.Application.Queries;
using Catalog.Core.DTOs.Types;
using Catalog.Core.Models.Types;
using Catalog.Infrastructure;
using Catalog.Application.Mappers;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetTypeByIdQueryHandler
        : IRequestHandler<GetTypeByIdQuery, TypeDTO>
    {
        private readonly TypeRepository _typeRepository;

        public GetTypeByIdQueryHandler(TypeRepository typeRepository)
        {
            this._typeRepository = typeRepository;
        }

        public  async Task<TypeDTO> Handle(GetTypeByIdQuery request, 
            CancellationToken cancellationToken)
        {
            TypeModel? typeModel
                = this._typeRepository.Types
                   .Where(e => e.Id == request.Id).FirstOrDefault();

            if (typeModel == null)
                throw new Exception("Type Model is not null or Empty");

            return typeModel.ToTypeMapper();
        }
    }
}
