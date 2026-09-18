using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.DTOs.Brands;
using Catalog.Core.Models.Brands;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllBrandQueryHandler
        : IRequestHandler<GetAllBrandQuery, List<BrandDTO>>
    {

        private readonly BrandRepository _brandRepository;
        public GetAllBrandQueryHandler(BrandRepository brandRepository)
        {
            this._brandRepository = brandRepository;
        }

        public async Task<List<BrandDTO>> Handle(GetAllBrandQuery request, 
            CancellationToken cancellationToken)
        {
            List<BrandModel> brandModels
                =  this._brandRepository.Brands.ToList();

            return brandModels.ToBrandMappers();
        }
    }
}
