using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.DTOs.Types;
using Catalog.Core.Models.Types;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllTypeQueryHandler
        : IRequestHandler<GetAllTypeQuery, List<TypeDTO>>
    {
        private readonly TypeRepository _typeRepository;

        public GetAllTypeQueryHandler(TypeRepository typeRepository)
        {
            this._typeRepository = typeRepository;
        }

        public async Task<List<TypeDTO>> Handle(GetAllTypeQuery request,
            CancellationToken cancellationToken)
        {
            List<TypeModel> typeModels
                = this._typeRepository.Types.ToList();

            return typeModels.ToTypeMappers();
        }
    }
}
