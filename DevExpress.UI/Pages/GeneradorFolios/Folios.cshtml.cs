using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TBSExam.Service.Interfaces;

namespace DevExpress.UI.Pages.GeneradorFolios
{
    public class FoliosModel : PageModel
    {
        private readonly IFolioService _folioService;
        private readonly ISaveService _saveService;
        public FoliosModel(IFolioService folioService, ISaveService saveService)
        {
            _folioService = folioService;
            _saveService = saveService;
        }

        [BindProperty]
        [Required(ErrorMessage = "Campo Requerido")]
        public string FolioInicial { get; set; } = default!;
        [BindProperty]
        [Required(ErrorMessage = "Campo Requerido")]
        public string FolioFinal { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var folios = _folioService.Create(FolioInicial, FolioFinal);
            await _saveService.Save();
            return Page();
        }
    }
}
