using EstoreModel.Models.Products;
using EstoreModel.Services;
using Microsoft.AspNetCore.Mvc;

namespace EStoreAdminModule.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            List<ProductModel> products = 
                this._productService.GetAllProducts();

            return View(products);
        }

        [HttpGet]
        [Route("CreateProduct")]
        public ActionResult CreateProduct()
        {
            return View();
        }
    }
}
