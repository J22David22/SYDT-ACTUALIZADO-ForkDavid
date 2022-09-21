using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class VerPersonaModel : PageModel
    {
        //Conectarse a la BDs
        private static IRepositorioPersona _repositorioPersona = new RepositorioPersona(new Hospital.App.Persistencia.AppContext());

        // Generamos una variable para mapear que llega del usuario desde la BDs
        [BindProperty]
        public Persona Persona { get; set; }

        //constructor
        public VerPersonaModel()
        {}

        public ActionResult OnGet(int id)
        {
            this.Persona = _repositorioPersona.GetPersona(id);
            return Page();
        }
    }
}
