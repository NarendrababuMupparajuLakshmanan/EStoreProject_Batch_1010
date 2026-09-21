using Catalog.Application.Commands;
using Catalog.Core.Models.Brands;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class DeleteBrandCommandHandler
        : IRequestHandler<DeleteBrandCommand, bool>
    {
        private readonly BrandRepository _brandRepository;

        public DeleteBrandCommandHandler(BrandRepository brandRepository)
        {
            this._brandRepository = brandRepository;
        }

        public async Task<bool> Handle(DeleteBrandCommand request, 
            CancellationToken cancellationToken)
        {
            BrandModel? brandModel
                = this._brandRepository.Brands.Where(e => e.Id == request.Id).FirstOrDefault();

            if (brandModel == null)
            {
                throw new Exception("Brand Model is not null oe empty");
            }

            this._brandRepository.Remove(brandModel);
            this._brandRepository.SaveChanges();

            return true;
        }
    }
}
