using EstoreModel.Models.Types;

namespace EstoreModel.Services
{
    public interface ITypeService
    {
        List<TypeModel> ListTypes();

        void DeleteType(Guid Id);

        void CreateType(CreateTypeModel createTypeModel);

        UpdateTypeModel EditType(Guid Id);

        void UpdateType(UpdateTypeModel updateTypeModel);
    }
}
