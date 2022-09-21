using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class EliminarPersonaModel : PageModel
    {
        // Conectarse a la base de datos

        private static IRepositorioPersona _repoPersona = new RepositorioPersona (new Hospital.App.Persistencia.AppContext());

        // Creamos variable para mapear que llega el usuario desde la base de datos

        public Persona persona {get;set;}

        // Constructor

        public EliminarPersonaModel()
        {

        }
        public ActionResult OnGet(int id)
        {
            this.persona=_repoPersona.GetPersona(id);
            return Page();
        }
        public ActionResult OnPost(int id)
        {
            try
            {
                _repoPersona.DeletePersona(id);
                return RedirectToPage("./ListadoPersonas");
            }
            catch (Exception e)
            {
                ViewData["Error"]=e.Message;
                return Page();
            }
        }
    }
}
