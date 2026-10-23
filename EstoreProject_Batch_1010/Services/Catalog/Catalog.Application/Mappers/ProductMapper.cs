using Catalog.Core.DTOs.Brands;
using Catalog.Core.DTOs.Products;
using Catalog.Core.DTOs.Types;
using Catalog.Core.Models.Products;

namespace Catalog.Application.Mappers
{
    /// <summary>
    /// build an Extension method to map ProductModel to ProductDTO
    /// </summary>
    public static class ProductMapper
    {

        public static List<ProductDTO> ToProductListDTO
            (this List<ProductListModel> productListModel)
        {
            if (productListModel == null || !productListModel.Any())
            {
                return new List<ProductDTO>();
            }

            List<ProductDTO> productDTOs = new List<ProductDTO>();

            foreach (var productModel in productListModel)
            {
                productDTOs.Add(new ProductDTO(
                    productModel.Id,
                    productModel.ProductName,
                    productModel.ProductDescription,
                    productModel.ImageName,
                    productModel.ImageUrl,
                    productModel.Brands != null ? new BrandDTO(productModel.Brands.Id, productModel.Brands.Name) : null,
                    productModel.Types != null ? new TypeDTO(productModel.Types.Id, productModel.Types.Name) : null,
                    productModel.Price,
                    productModel.GST,
                    productModel.TotalCost
                ));
            }

            return productDTOs;
        }
    }
}
