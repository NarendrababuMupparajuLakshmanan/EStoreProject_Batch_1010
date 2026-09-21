using Catalog.Application.Commands;
using Catalog.Core.Models.Brands;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class UpdateBrandCommandHandler
        : IRequestHandler<UpdateBrandCommand, bool>
    {
        private readonly BrandRepository _brandRepository;

        public UpdateBrandCommandHandler(BrandRepository brandRepository)
        {
            this._brandRepository = brandRepository;
        }

        public async Task<bool> Handle(UpdateBrandCommand request, 
            CancellationToken cancellationToken)
        {
            BrandModel brandModel
                = new BrandModel()
                {
                    Id = request.updateBrandDTO.Id,
                    Name = request.updateBrandDTO.Name
                };

            this._brandRepository.Update(brandModel);
            this._brandRepository.SaveChanges();

            return true;
            
        }
    }
}
