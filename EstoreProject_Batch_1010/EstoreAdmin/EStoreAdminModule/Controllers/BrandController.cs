
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
        [Route("ListBrand")]
        public IActionResult ListBrand()
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

            return RedirectToAction("ListBrand");
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

            return RedirectToAction("ListBrand");
        }

        [HttpGet]
        [Route("EditBrand/{Id:guid}")]
        public ActionResult EditBrand(Guid Id) 
        {

            UpdateBrandMOdel updateBrandMOdel
                = this._brandService.EditBrand(Id);

            return View(updateBrandMOdel);
        }

        [HttpPost]
        [Route("EditBrand/{Id:guid}")]
        public ActionResult EditBrand(Guid Id, UpdateBrandMOdel updateBrandMOdel)
        {

            this._brandService.UpdateBrand(updateBrandMOdel);

            return RedirectToAction("ListBrand");
        }
    }
}
