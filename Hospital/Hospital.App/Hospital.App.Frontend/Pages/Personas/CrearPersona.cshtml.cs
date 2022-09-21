using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class CrearPersonaModel : PageModel
    
    {
        private static IRepositorioPersona _repositorioPersona = new RepositorioPersona( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public Persona Persona {get; set;}

        public CrearPersonaModel()
        {}

        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            try{
                
                Persona personaAdicionado = _repositorioPersona.AddPersona(Persona);
                return RedirectToPage("./ListadoPersonas");
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
