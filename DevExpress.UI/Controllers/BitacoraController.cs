using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBSExam.Service.Interfaces;

namespace DevExpress.UI.Controllers
{
	public class BitacoraController : Controller
	{
		private readonly IBitacoraService _bitacoraService;
        public BitacoraController(IBitacoraService bitacoraService)
        {
            _bitacoraService = bitacoraService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var bitacora = await _bitacoraService.GetAll();
            return Json(DataSourceLoader.Load(bitacora, loadOptions));
        }
    }
}
