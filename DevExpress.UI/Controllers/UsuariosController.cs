using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TBSExam.Models.Models;
using TBSExam.Service.Interfaces;

namespace DevExpress.UI.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ISaveService _saveService;
        private readonly IBitacoraService _bitacoraService;
        public UsuariosController(IUsuarioService usuarioService, ISaveService saveService, IBitacoraService bitacoraService)
        {
            _usuarioService = usuarioService;
            _saveService = saveService;
            _bitacoraService = bitacoraService;

        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var usuarios = await _usuarioService.GetAll();
            return Json(DataSourceLoader.Load(usuarios, loadOptions));
        }

        [HttpPut]
        public async Task<IActionResult> Update(int key, string values)
        {
            var usuarioLogin = HttpContext.Session.GetString("usuarioLogin");
            var update = await _usuarioService.Update(key, values, usuarioLogin);
            if (!update) return BadRequest();
            else return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string values)
        {
            var usuarioLogin = HttpContext.Session.GetString("usuarioLogin");
            var create = await _usuarioService.Create(values, usuarioLogin);
            if (!create) return BadRequest();
            else return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int key)
        {
            var usuarioLogin = HttpContext.Session.GetString("usuarioLogin");
            var delete = await _usuarioService.Delete(key, usuarioLogin);
            if(!delete) return BadRequest();
            else return Ok();
        }
    }
}
