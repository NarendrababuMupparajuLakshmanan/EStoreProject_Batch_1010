using Catalog.Application.Commands;
using Catalog.Core.Models.Brands;
using Catalog.Infrastructure;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class CreateBrandCommandHandler
        : IRequestHandler<CreateBrandCommand, Guid>
    {
        private readonly BrandRepository _brandRepository;

        public CreateBrandCommandHandler(BrandRepository brandRepository)
        {
            this._brandRepository = brandRepository;
        }


        public async Task<Guid> Handle(CreateBrandCommand request, 
            CancellationToken cancellationToken)
        {
            BrandModel brandModel
               = new BrandModel()
               {
                   Id = Guid.NewGuid(),
                   Name = request.Name
               };

            this._brandRepository.Add(brandModel);
            this._brandRepository.SaveChanges();

            return  brandModel.Id;
        }
    }
}
