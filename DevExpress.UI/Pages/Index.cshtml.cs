using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [BindProperty]
        [Required(ErrorMessage = "Usuario Requerido")]
        public string User { get; set; } = default!;
        [BindProperty]
        [Required(ErrorMessage = "Contraseña Requerida")]
        public string Password { get; set; } = default!;
        public IActionResult OnGet() {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var usuario = await _usuarioService.Login(User, Password);
            if (usuario == null) return Page();
            HttpContext.Session.SetString("usuarioLogin", usuario.usuario_id.ToString());
            var fecha = await _usuarioService.LastLogin(usuario);
            await _saveService.Save();
            return RedirectToPage("/MainPage/PaginaPrincipal");
        }
    }
}
