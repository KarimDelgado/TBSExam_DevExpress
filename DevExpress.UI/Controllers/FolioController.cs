using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using TBSExam.Service.Interfaces;

namespace DevExpress.UI.Controllers
{
    public class FolioController : Controller
    {
        private readonly IFolioService _folioService;
        public FolioController(IFolioService folioService)
        {
            _folioService = folioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var folios = await _folioService.GetAll();
            return Json(DataSourceLoader.Load(folios, loadOptions));
        }
    }
}
