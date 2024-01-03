﻿using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TBSExam.Service.Interfaces;

namespace DevExpress.UI.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;

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
            if (!update) 
            {
                ModelState.AddModelError(string.Empty, "Error al editar usuario");
                return View();
            } 
            else return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string values)
        {
            var usuarioLogin = HttpContext.Session.GetString("usuarioLogin");
            var create = await _usuarioService.Create(values, usuarioLogin);
            if (!create) 
            {
                ModelState.AddModelError(string.Empty, "Error al registrar usuario");
                return View();
            } 
            else return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int key)
        {
            var usuarioLogin = HttpContext.Session.GetString("usuarioLogin");
            var delete = await _usuarioService.Delete(key, usuarioLogin);
            if (!delete) 
            {
                ModelState.AddModelError(string.Empty, "Error al eliminar usuario");
                return View(); 
            } 
            else return Ok();
        }
    }
}
