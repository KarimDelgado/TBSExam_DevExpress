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
            var usuario = await _usuarioService.GetById(key);
            JsonConvert.PopulateObject(values, usuario);
            if (!TryValidateModel(usuario))
                return BadRequest();
            var usuarioLogin = HttpContext.Session.GetString("usuarioLogin");
            await _bitacoraService.Create("Editar", usuarioLogin);
            await _saveService.Save();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string values)
        {
            var newUsuario = new Usuario();
            JsonConvert.PopulateObject(values, newUsuario);
            if (!TryValidateModel(newUsuario))
                return BadRequest();
            var usuarioLogin = HttpContext.Session.GetString("usuarioLogin");
            await _usuarioService.Create(newUsuario);
            await _bitacoraService.Create("Crear", usuarioLogin);
            await _saveService.Save();
            return Ok(new Usuario());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int key)
        {
            var usuario = await _usuarioService.GetById(key);
            if (usuario == null)
                return BadRequest();
            var usuarioLogin = HttpContext.Session.GetString("usuarioLogin");
            await _usuarioService.Delete(key);
            await _bitacoraService.Create("Eliminar", usuarioLogin);
            await _saveService.Save();
            return Ok();
        }
    }
}
