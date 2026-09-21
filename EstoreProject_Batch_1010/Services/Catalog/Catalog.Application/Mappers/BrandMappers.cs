using Catalog.Core.DTOs.Brands;
using Catalog.Core.Models.Brands;
using System.Runtime.CompilerServices;

namespace Catalog.Application.Mappers
{
    public static class BrandMappers
    {

        public static List<BrandDTO> ToBrandMappers
            (this List<BrandModel> brandmodels)
        {
            List<BrandDTO> brandDTOs = null;
            if (brandmodels != null)
            {
                 brandDTOs  = new List<BrandDTO>();

                foreach (BrandModel brandModel in brandmodels)
                {
                    brandDTOs.Add(new BrandDTO(brandModel.Id, brandModel.Name));
                }
            }

            return brandDTOs;
        }


        public static BrandDTO ToBrandMapper
        (this BrandModel brandmodel)
        {
            BrandDTO brandDTO = null;
            if (brandmodel != null)
            {
                brandDTO = new BrandDTO(brandmodel.Id, brandmodel.Name);
            }

            return brandDTO;
        }

    }
}
