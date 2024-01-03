using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TBSExam.Service.Interfaces;

namespace DevExpress_UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUsuarioService _usuarioService;
        public IndexModel(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [BindProperty]
        [Required(ErrorMessage = "Usuario Requerido")]
        public new string User { get; set; } = default!;
        [BindProperty]
        [Required(ErrorMessage = "Contraseña Requerida")]
        public string Password { get; set; } = default!;
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var usuario = await _usuarioService.Login(User, Password);
            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Usuario Incorrecto");
                return Page();
            }
            HttpContext.Session.SetString("usuarioLogin", usuario.usuario_id.ToString());
            return RedirectToPage("/MainPage/PaginaPrincipal");
        }
    }
}
