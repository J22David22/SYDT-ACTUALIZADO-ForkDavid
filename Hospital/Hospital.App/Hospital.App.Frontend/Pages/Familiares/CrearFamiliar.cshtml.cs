using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class CrearFamiliarModel : PageModel
    
    {
        private IRepositorioFamiliar _repositorioFamiliar = new RepositorioFamiliar( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public Familiar familiar {get; set;}

        public CrearFamiliarModel()
        {}

        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            try{
                
                Familiar familiarAdicionado = _repositorioFamiliar.AddFamiliar(familiar);
                return RedirectToPage("/Auxiliares/AdminAuxFmliar");
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
