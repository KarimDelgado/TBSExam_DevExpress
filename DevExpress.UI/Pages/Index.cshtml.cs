using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TBSExam.Models.Models;
using TBSExam.Service.Interfaces;

namespace DevExpress_UI.Pages {
    public class IndexModel : PageModel {
        private readonly IUsuarioService _usuarioService;
        private readonly ISaveService _saveService;
        public IndexModel(IUsuarioService usuarioService, ISaveService saveService)
        {
            _usuarioService = usuarioService;
            _saveService = saveService;
        }
        public IActionResult OnGet() {
            return Page();
        }

        public async Task<IActionResult> OnPost(string Usuario, string Password)
        {
            var usuario = await _usuarioService.Login(Usuario, Password);
            if (usuario == null) return Page();
            HttpContext.Session.SetString("usuarioLogin", usuario.usuario_id.ToString());
            var fecha = await _usuarioService.LastLogin(usuario);
            await _saveService.Save();
            return RedirectToPage("/Mantenimiento/Usuarios");
        }
    }
}
