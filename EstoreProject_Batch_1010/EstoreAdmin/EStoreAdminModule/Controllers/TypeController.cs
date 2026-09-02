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

        [HttpGet]
        [Route("CreateType")]
        public ActionResult CreateType()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateType")]
        public ActionResult CreateType(CreateTypeModel createTypeModel)
        {
            this._typeService.CreateType(createTypeModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("EditType/{id:guid}")]
        public IActionResult EditType(Guid id)
        {

            UpdateTypeModel updateTypeModel
                = this._typeService.EditType(id);

            return View(updateTypeModel);
        }

        [HttpPost]
        [Route("UpdateType/{Id:guid}")]
        public ActionResult UpdateType(UpdateTypeModel updateTypeModel, Guid Id)
        {

            this._typeService.UpdateType(updateTypeModel);

            return RedirectToAction("Index");
        }
    }
}
