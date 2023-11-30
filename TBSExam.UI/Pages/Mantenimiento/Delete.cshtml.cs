using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TBSExam.Data.ExamContext;
using TBSExam.Data.Repositories.Interfaz;
using TBSExam.Models.Models;
using TBSExam.Service.Interfaces;

namespace TBSExam.UI.Pages.Mantenimiento
{
    public class DeleteModel : PageModel
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IBitacoraService _bitacoraService;
        public DeleteModel(IUsuarioService usuarioService, IBitacoraService bitacoraService)
        {
            _bitacoraService = bitacoraService;
            _usuarioService = usuarioService;
        }

        [BindProperty]
      public Usuario Usuario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _usuarioService.GetById(id);

            if (usuario == null)
            {
                return NotFound();
            }
            else 
            {
                Usuario = usuario;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (Usuario != null)
            {
                var delete = await _usuarioService.Delete(id);
                var registro = await _bitacoraService.Create("Eliminar", DateTime.Now, 2);
            }

            return RedirectToPage("./Index");
        }
    }
}
