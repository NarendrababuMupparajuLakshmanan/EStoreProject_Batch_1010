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

            BrandModel model = new BrandModel();

            model.Id = Guid.NewGuid();
            model.Name = "Samsung";

            return Ok(model);
        }
    }
}
