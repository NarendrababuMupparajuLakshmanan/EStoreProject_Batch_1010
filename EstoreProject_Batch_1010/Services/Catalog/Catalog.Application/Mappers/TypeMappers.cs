using Catalog.Core.DTOs.Brands;
using Catalog.Core.DTOs.Types;
using Catalog.Core.Models.Brands;
using Catalog.Core.Models.Types;

namespace Catalog.Application.Mappers
{
    public static class TypeMappers
    {

        public static List<TypeDTO> ToTypeMappers
            (this List<TypeModel> typemodels)
        {
            List<TypeDTO> typeDTOs = null;
            if (typemodels != null)
            {
                typeDTOs = new List<TypeDTO>();

                foreach (TypeModel typeModel in typemodels)
                {
                    typeDTOs.Add(new TypeDTO(typeModel.Id, typeModel.Name));
                }
            }

            return typeDTOs;
        }


        public static TypeDTO ToTypeMapper
        (this TypeModel typemodel)
        {
            TypeDTO typeDTO = null;
            if (typemodel != null)
            {
                typeDTO = new TypeDTO(typemodel.Id, typemodel.Name);
            }

            return typeDTO;
        }

    }
}
