using Catalog.Application.Queries;
using Catalog.Core.DTOs.Brands;
using Catalog.Core.Models.Brands;
using Catalog.Application.Mappers;
using Catalog.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Handlers
{
    public class GetBrandByIdQueryHandler
        : IRequestHandler<GetBrandByIdQuery, BrandDTO>
    {
        private readonly BrandRepository _brandRepository;

        public GetBrandByIdQueryHandler(BrandRepository brandRepository)
        {
            this._brandRepository = brandRepository;
        }

        public async Task<BrandDTO> Handle(GetBrandByIdQuery request, 
            CancellationToken cancellationToken)
        {
            BrandModel? brandModel
                = await this._brandRepository.Brands.
                    Where(e => e.Id == request.Id).FirstOrDefaultAsync();

            return brandModel.ToBrandMapper();
        }
    }
}
