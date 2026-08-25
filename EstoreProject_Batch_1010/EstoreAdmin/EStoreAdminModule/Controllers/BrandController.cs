using EstoreModel.Models.Brands;
using Microsoft.AspNetCore.Mvc;

namespace EStoreAdminModule.Controllers
{
    public class BrandController : Controller
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {

            List<BrandModel> brandModels = new List<BrandModel>();

            brandModels.Add(new BrandModel()
            {
                Id = Guid.NewGuid(),
                Name = "Samsung"
            });

            brandModels.Add(new BrandModel()
            {
                Id = Guid.NewGuid(),
                Name = "Vivo"
            });

            brandModels.Add(new BrandModel()
            {
                Id = Guid.NewGuid(),
                Name = "Reliance"
            });

            ///Return a ViewModel Object to the Corresponding Views
            return View(brandModels);
        }
    }
}
