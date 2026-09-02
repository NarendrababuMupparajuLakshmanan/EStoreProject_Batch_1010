using EstoreModel.Models.Types;
using EstoreModel.Services;
using EStoreRepository;

namespace EStoreAdminService
{
    public class TypeService : ITypeService
    {
        private readonly TypeRepository _typeRepository;

        public TypeService(TypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public void CreateType(CreateTypeModel createTypeModel)
        {
            if (createTypeModel == null)
            {
                throw new ArgumentNullException(nameof(createTypeModel));
            }

            TypeModel typeModel = new TypeModel
            {
                Id = Guid.NewGuid(),
                Name = createTypeModel.Name
            };

            this._typeRepository.Types.Add(typeModel);
            this._typeRepository.SaveChanges();
        }

        public void DeleteType(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                throw new ArgumentException("Invalid Id");
            }

            TypeModel? typeModel
                = this._typeRepository.Types.Where(t => t.Id == Id).FirstOrDefault();

            if (typeModel == null)
            {
                throw new ArgumentException("Type not found");
            }

            this._typeRepository.Types.Remove(typeModel);
            this._typeRepository.SaveChanges();
        }

        public UpdateTypeModel EditType(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                throw new ArgumentException("Invalid Id");
            }

            TypeModel? typeModel
                = this._typeRepository.Types.Where(t => t.Id == Id).FirstOrDefault();

            UpdateTypeModel updateTypeModel = new UpdateTypeModel
            {
                Id = typeModel?.Id ?? Guid.Empty,
                Name = typeModel?.Name ?? string.Empty
            };

            return updateTypeModel;
        }

        public List<TypeModel> ListTypes()
        {
            List<TypeModel> types =
                this._typeRepository.Types.ToList();

            return types;
        }

        public void UpdateType(UpdateTypeModel updateTypeModel)
        {
            if (updateTypeModel == null)
            {
                throw new ArgumentNullException(nameof(updateTypeModel));
            }

            TypeModel typeModel = new TypeModel()
            {
                Id = updateTypeModel.Id,
                Name = updateTypeModel.Name
            };

            this._typeRepository.Types.Update(typeModel);
            this._typeRepository.SaveChanges();
        }
    }
}
