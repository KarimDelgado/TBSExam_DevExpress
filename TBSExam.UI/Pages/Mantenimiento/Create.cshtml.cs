using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TBSExam.Data.ExamContext;
using TBSExam.Data.Repositories.Interfaz;
using TBSExam.Models.Models;
using TBSExam.Service.Interfaces;

namespace TBSExam.UI.Pages.Mantenimiento
{
    public class CreateModel : PageModel
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IBitacoraService _bitacoraService;
        private readonly ISaveService _saveService;
        public CreateModel(IUsuarioService usuarioService, IBitacoraService bitacoraService, ISaveService saveService)
        {
            _usuarioService = usuarioService;
            _bitacoraService = bitacoraService;
            _saveService = saveService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(Usuario usuario)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
			var usuarioLogin = HttpContext.Session.GetString("usuarioLogin");
			var create = await _usuarioService.Create(usuario);
            var registro = await _bitacoraService.Create("Crear", usuarioLogin);
            await _saveService.Save();
            return RedirectToPage("./Index");
        }
    }
}
