using EstoreModel.Models.Brands;
using EstoreModel.Services;
using EStoreRepository;

namespace EStoreAdminService
{
    public class BrandService : IBrandService
    {
        private readonly BrandRepository _brandRepository;

        public BrandService(BrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public void CreateBrand(CreateBrandModel createBrandModel)
        {
            if (createBrandModel == null)
                throw new Exception("Create Brand is not null");

            BrandModel brandModel = new BrandModel()
            {
                Id = Guid.NewGuid(),
                Name = createBrandModel.Name,
            };

            this._brandRepository.Add(brandModel);
            this._brandRepository.SaveChanges();
        }

        public void DeleteBrand(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                throw new Exception("Brand Id is not null or Empty");
            }

            ///Get Brand based on Id
            BrandModel? brandModel
                = this._brandRepository.Brands.Where(e => e.Id == Id).FirstOrDefault();

            if (brandModel == null)
                throw new Exception("Brand Model Object is null or empty");

            this._brandRepository.Remove(brandModel);
            this._brandRepository.SaveChanges();
        }

        public UpdateBrandMOdel EditBrand(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                throw new Exception("Brand Id is not null or Empty");
            }

            BrandModel? brandModel
                = this._brandRepository.Brands.Where(e => e.Id == Id).FirstOrDefault();

            UpdateBrandMOdel updateBrandMOdel = new UpdateBrandMOdel()
            {
                Id = brandModel.Id,
                Name = brandModel.Name
            };

            return updateBrandMOdel;
        }

        public string GetBrandNameById(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                throw new Exception("Brand Id is not null or Empty");
            }

            BrandModel? brandModel
                = this._brandRepository.Brands.Where(e => e.Id == Id).FirstOrDefault();

            if (brandModel == null)
                throw new Exception("Brand Model Object is null or empty");

            return brandModel.Name;
        }

        public List<BrandModel> ListBrands()
        {

            List<BrandModel> brandModels =
                this._brandRepository.Brands.ToList();

            return brandModels;
        }

        public void UpdateBrand(UpdateBrandMOdel updateBrandMOdel)
        {
            if (updateBrandMOdel == null)
                throw new Exception("Update Brand is not null");

            BrandModel brandModel = new BrandModel()
            {
                Id = updateBrandMOdel.Id,
                Name = updateBrandMOdel.Name,
            };

            this._brandRepository.Update(brandModel);
            this._brandRepository.SaveChanges();
        }
    }
}
