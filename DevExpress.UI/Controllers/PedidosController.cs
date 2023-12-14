using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TBSExam.Models.Models;
using TBSExam.Service.Interfaces;

namespace DevExpress.UI.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

		[HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var pedidos = await _pedidoService.GetAll();
            return Json(DataSourceLoader.Load(pedidos, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Create(string values)
        {
            var usuarioLogin = HttpContext.Session.GetString("usuarioLogin");
            var create = await _pedidoService.Create(values, usuarioLogin);
            if(create == true) 
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int key, string values)
        {
            var update = await _pedidoService.Update(key, values);
            if(update == true)
                return Ok();
            else 
                return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int key)
        {
            var delete = await _pedidoService.Delete(key);
            if (delete == true)
                return Ok();
            else
                return BadRequest();
        }
    }
}
