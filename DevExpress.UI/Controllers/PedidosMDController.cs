using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using TBSExam.Service.Interfaces;

namespace DevExpress.UI.Controllers
{
    public class PedidosMDController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IPedidoService _pedidoService;
        public PedidosMDController(IUsuarioService usuarioService, IPedidoService pedidoService)
        {
            _usuarioService = usuarioService;
            _pedidoService = pedidoService;

        }

        [HttpGet]
        public async Task<IActionResult> GetUsuario(DataSourceLoadOptions loadOptions)
        {
            var usuarios = await _usuarioService.GetAll();
            return Json(DataSourceLoader.Load(usuarios, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> GetPedido(int id, DataSourceLoadOptions loadOptions)
        {
            var pedidos = await _usuarioService.ListMD(id);
            return Json(DataSourceLoader.Load(pedidos, loadOptions));
        }
    }
}
