using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string folioInicial, string folioFinal)
        {
            var folios = _folioService.Create(folioInicial, folioFinal);
            await _saveService.Save();
            return Page();
        }
    }
}
