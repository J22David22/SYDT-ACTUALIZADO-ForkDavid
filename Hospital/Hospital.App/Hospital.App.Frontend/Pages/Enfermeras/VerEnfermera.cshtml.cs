using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class VerEnfermeraModel : PageModel
    {
        //Conectarse a la BDs
        private static IRepositorioEnfermera _repositorioEnfermera = new RepositorioEnfermera(new Hospital.App.Persistencia.AppContext());

        // Generamos una variable para mapear que llega del usuario desde la BDs
        [BindProperty]
        public Enfermera enfermera { get; set; }

        //constructor
        public VerEnfermeraModel()
        {}

        public ActionResult OnGet(int id)
        {
            enfermera = _repositorioEnfermera.GetEnfermera(id);
            return Page();
        }
    }
}
