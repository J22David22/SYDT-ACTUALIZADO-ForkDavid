using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;


namespace Hospital.App.Frontend.Pages
{
    public class EditarPersonaModel : PageModel
   {
        private static IRepositorioPersona _repositorioPersona = new RepositorioPersona( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public Persona persona {get; set;}

        public ActionResult OnGet(int id)
        {
            this.persona = _repositorioPersona.GetPersona(id);
            return Page();
        }

        public ActionResult OnPost()
        {
            try{
                Persona personaActualizado = _repositorioPersona.UpdatePersona(persona);
                return RedirectToPage("./ListadoPersonas");
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    
}
}
