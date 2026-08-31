
using EstoreModel.Models.Brands;
using EstoreModel.Services;
using Microsoft.AspNetCore.Mvc;

namespace EStoreAdminModule.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
   
        /// <summary>
        /// Constructor has dependency Injection of IBrandService
        /// </summary>
        /// <param name="brandService"></param>
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
     
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {

            List<BrandModel> brandModels = null;

            brandModels = this._brandService.ListBrands();
          
            ///Return a ViewModel Object to the Corresponding Views
            return View(brandModels);
        }

        [HttpGet]
        [Route("DeleteBrand/{Id:guid}")]
        public ActionResult DeleteBrand(Guid Id)
        {
            this._brandService.DeleteBrand(Id);

            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("CreateBrand")]
        public ActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public ActionResult CreateBrand(CreateBrandModel createBrandModel)
        {
            this._brandService.CreateBrand(createBrandModel);

            return RedirectToAction("Index");
        }
    }
}
