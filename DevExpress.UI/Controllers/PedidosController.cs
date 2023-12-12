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
        private readonly ISaveService _saveService;
        private readonly IFolioService _folioService;

        public PedidosController(IPedidoService pedidoService, ISaveService saveService, IFolioService folioService)
        {
            _folioService = folioService;
            _pedidoService = pedidoService;
            _saveService = saveService;
        }

        [BindProperty]
		public string FolioPedido { get; set; } = default!;
        [BindProperty]
        public bool RegistroExitoso { get; set; } = false;

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
            var folio = await _folioService.GetbyAvaible(true);
            var newPedido = new Pedido
            {
                usuario_id = int.Parse(usuarioLogin),
                folio_id = folio.folio_id
            };
            JsonConvert.PopulateObject(values, newPedido);
            if (!TryValidateModel(newPedido))
                return BadRequest();
            FolioPedido = folio.folio_id;
            var create = await _pedidoService.Create(newPedido);
            await _folioService.Update(folio, false);
            await _saveService.Save();
            if(create == true)
            {
                RegistroExitoso = true;
            }
            return Ok(new Pedido());
        }

        [HttpPut]
        public async Task<IActionResult> Update(int key, string values)
        {
            var pedido = await _pedidoService.GetById(key);
            JsonConvert.PopulateObject(values, pedido);
            if (!TryValidateModel(pedido))
                return BadRequest();
            await _saveService.Save();
            return Ok(pedido);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int key)
        {
            var pedido = await _pedidoService.GetById(key);
            if(pedido == null)
                return BadRequest();
            var folio = await _folioService.GetById(pedido.folio_id);
            await _pedidoService.Delete(key);
            await _folioService.Update(folio, true);
            await _saveService.Save();
            return Ok();
        }
    }
}
