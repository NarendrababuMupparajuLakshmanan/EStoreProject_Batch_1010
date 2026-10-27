using Discount.Core.DTOs;
using Discount.Core.Model.Discounts;

namespace Discount.Application.Mappers
{
    public static class DIscountMapper
    {
        public static List<DiscountReadDTO>
            ToMapDiscounts(this List<DiscountModel> discountModels)
        {
            List<DiscountReadDTO> discountReadDTOs = null;

            if (discountModels != null)
            {
                discountReadDTOs = new List<DiscountReadDTO>();

                foreach(DiscountModel discountModel in discountModels)
                {
                    discountReadDTOs.Add(discountModel.ToMapDiscount());
                }
            }

            return discountReadDTOs;
        }



        public static DiscountReadDTO
            ToMapDiscount(this DiscountModel discountModel)
        {
            DiscountReadDTO discountDTO = null;

            if (discountModel != null)
            {
                discountDTO = new DiscountReadDTO(
                    discountModel.ProductID,
                    discountModel.DiscountPercentage,
                    discountModel.DiscountAmount);
            }

            return discountDTO;
        }
    }
}
