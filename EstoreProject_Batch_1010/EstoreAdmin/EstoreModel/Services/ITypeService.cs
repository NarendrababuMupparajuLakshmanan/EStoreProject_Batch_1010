using EstoreModel.Models.Types;

namespace EstoreModel.Services
{
    public interface ITypeService
    {
        List<TypeModel> ListTypes();

        void DeleteType(Guid Id);
    }
}
