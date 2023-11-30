using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
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
        public async Task<IActionResult> Update(int usuario_id, string values)
        {
            var usuario = await _usuarioService.GetById(usuario_id);
            JsonConvert.PopulateObject(values, usuario);
            if (!TryValidateModel(usuario))
                return BadRequest();
            await _saveService.Save();
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string values)
        {
            var newUsuario = new Usuario();
            JsonConvert.PopulateObject(values, newUsuario);
            if(!TryValidateModel(newUsuario))
                return BadRequest();
            await _usuarioService.Create(newUsuario);
            await _bitacoraService.Create("Crear", 2);
            await _saveService.Save();
            return Ok(new Usuario());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _usuarioService.GetById(id);
            if(usuario == null)
                return BadRequest();
            await _usuarioService.Delete(id);
            await _saveService.Save();
            return Ok();
        }
    }
}
