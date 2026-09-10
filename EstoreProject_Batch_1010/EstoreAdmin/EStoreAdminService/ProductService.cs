using EstoreModel.Models.Products;
using EstoreModel.Services;
using EStoreRepository;

namespace EStoreAdminService
{
    public class ProductService : IProductService
    {
        private readonly IBrandService _brandService;
        private readonly ITypeService _typeService;
        private readonly ProductRepository _productRepository;
        
        public ProductService(ProductRepository productRepository,
            IBrandService brandService,
            ITypeService typeService)
        {
            _brandService = brandService;
            _typeService = typeService;
            _productRepository = productRepository;
   
        }

        public void CreateProduct(CreateProductModel createProductModel, string ImageFullPath)
        {
            if (createProductModel == null)
            {
                throw new ArgumentNullException(nameof(createProductModel));
            }

            if (createProductModel.UploadImage != null)
            {
                string ImageName = Guid.NewGuid().ToString();
                ImageName = ImageName + Path.GetExtension(createProductModel.UploadImage.FileName);

                ImageFullPath += ImageName;


                //Save the image to the specified path
                using (var stream = new FileStream(ImageFullPath, FileMode.Create))
                {
                    createProductModel.UploadImage.CopyTo(stream);
                }

                //Build Logic for GST
               int totalCost = CaculateGSTAmount(createProductModel.ProductPrice);

                //SAve data to the database
                ProductModel productModel = new ProductModel
                {
                    Id = Guid.NewGuid(),
                    ProductName = createProductModel.ProductName,
                    ProductDescription = createProductModel.ProductDescription,
                    BrandId = createProductModel.BrandId,
                    TypeId = createProductModel.TypeId,
                    Price = createProductModel.ProductPrice,
                    GST = totalCost,
                    ImageUrl = ImageFullPath,
                    ImageName = ImageName,
                    TotalCost = totalCost
                };

                this._productRepository.Products.Add(productModel);
                this._productRepository.SaveChanges();

            }

        }

        public int CaculateGSTAmount(int price)
        {
            decimal gstAmount = (price + ((price * 18) / 100));
            return (int)gstAmount;
        }

        public List<ProductList> GetAllProducts()
        {
            List<ProductList> productList = new List<ProductList>();

            List<ProductModel> products = 
                this._productRepository.Products.ToList();

            if (products != null && products.Count != 0)
            {
                foreach (ProductModel productModel in products)
                {
                    ProductList product = new ProductList
                    {
                        Id = productModel.Id,
                        ProductName = productModel.ProductName,
                        ProductDescription = productModel.ProductDescription,
                        ImageName = productModel.ImageName,
                        ImageUrl = productModel.ImageUrl,
                        TypeName = this._typeService.GetTypeNameById(productModel.TypeId),
                        BrandName = this._brandService.GetBrandNameById(productModel.BrandId),
                        Price = productModel.Price,
                        GST = productModel.GST,
                        TotalCost = productModel.TotalCost
                    };

                    productList.Add(product);
                }
            }

            return productList;
        }

        public void DeleteProduct(Guid Id, string ImageFullPath)
        {
            if (Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(Id));
            }

            ProductModel? productModel=
                this._productRepository.Products.Where(p => p.Id == Id).FirstOrDefault();

            //Delete the Product Image from the server
             ImageFullPath += productModel.ImageName.ToString();

            File.Delete(ImageFullPath);

            this._productRepository.Products.Remove(productModel);
            this._productRepository.SaveChanges();
        }
    }
}
