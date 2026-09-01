using EstoreModel.Models.Types;
using EstoreModel.Services;
using Microsoft.AspNetCore.Mvc;

namespace EStoreAdminModule.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }


        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            List<TypeModel> types =
                this._typeService.ListTypes();

            return View(types);
        }

        [HttpGet]
        [Route("DeleteType/{Id:guid}")]
        public ActionResult DeleteType(Guid Id)
        {
            this._typeService.DeleteType(Id);

            return RedirectToAction("Index");
        }
    }
}
