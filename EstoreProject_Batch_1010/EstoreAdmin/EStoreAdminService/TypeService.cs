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

        public List<TypeModel> ListTypes()
        {
            List<TypeModel> types =
                this._typeRepository.Types.ToList();

            return types;
        }
    }
}
