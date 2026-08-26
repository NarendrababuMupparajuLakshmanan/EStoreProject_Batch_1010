
using EstoreModel.Models.Brands;
using EstoreModel.Services;
using Microsoft.AspNetCore.Mvc;

namespace EStoreAdminModule.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IBrandService _brandService1;
        private readonly IBrandService _brandService2;

        /// <summary>
        /// Constructor has dependency Injection of IBrandService
        /// </summary>
        /// <param name="brandService"></param>
        public BrandController(IBrandService brandService,
            IBrandService brandService1,
            IBrandService brandService2)
        {
            _brandService = brandService;
            _brandService1 = brandService1;
            _brandService2 = brandService2;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {

            ViewBag.BrandService = this._brandService.GetHashCode();
            ViewBag.BrandService1 = this._brandService1.GetHashCode();
            ViewBag.BrandService2 = this._brandService2.GetHashCode();

            List<BrandModel> brandModels = null;

            brandModels = this._brandService.ListBrands();
          
            ///Return a ViewModel Object to the Corresponding Views
            return View(brandModels);
        }
    }
}
