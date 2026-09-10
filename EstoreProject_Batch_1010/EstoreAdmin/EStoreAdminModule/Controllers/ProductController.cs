using EstoreModel.Models.Brands;
using EstoreModel.Models.Products;
using EstoreModel.Models.Types;
using EstoreModel.Services;
using Microsoft.AspNetCore.Mvc;

namespace EStoreAdminModule.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ITypeService _typeService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductService productService,
            IBrandService brandService,
            ITypeService typeService,
            IWebHostEnvironment webHostEnvironment)
        {
            this._productService = productService;
            this._brandService = brandService;
            this._typeService = typeService;
            this._webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            List<ProductList> products = 
                this._productService.GetAllProducts();

            return View(products);
        }

        [HttpGet]
        [Route("CreateProduct")]
        public ActionResult CreateProduct()
        {
            List<BrandModel> brands = this._brandService.ListBrands();

            List<TypeModel> types = this._typeService.ListTypes();

            ViewBag.Brands = brands;
            ViewBag.Types = types;

            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public ActionResult CreateProduct(CreateProductModel createProductModel)
        {

            string ImageFullPath = this._webHostEnvironment.ContentRootPath;

            ImageFullPath = ImageFullPath + "\\wwwroot\\ProductImages\\";

            this._productService.CreateProduct(createProductModel, ImageFullPath);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("DeleteProduct/{Id:guid}")]
        public ActionResult DeleteProduct(Guid Id)
        {

            string ImageFullPath = this._webHostEnvironment.ContentRootPath;

            ImageFullPath = ImageFullPath + "\\wwwroot\\ProductImages\\";

            this._productService.DeleteProduct(Id, ImageFullPath);
            return RedirectToAction("Index");
        }
    }
}
