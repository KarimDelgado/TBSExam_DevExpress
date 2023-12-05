using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using TBSExam.Service.Interfaces;
using Newtonsoft.Json;
using TBSExam.Models.Models;

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

        [HttpPost]
        public async Task<IActionResult> Create(string values)
        {
            var newFolio = new Folio();
            return Ok(new Folio());
        }
    }
}
