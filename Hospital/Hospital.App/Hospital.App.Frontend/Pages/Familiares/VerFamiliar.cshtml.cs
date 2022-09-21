using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class VerFamiliarModel : PageModel
    {
        //Conectarse a la BDs
        private IRepositorioFamiliar _repositorioFamiliar = new RepositorioFamiliar(new Hospital.App.Persistencia.AppContext());

        // Generamos una variable para mapear que llega del usuario desde la BDs
        [BindProperty]
        public Familiar familiar { get; set; }

        //constructor
        public VerFamiliarModel()
        {}

        public ActionResult OnGet(int id)
        {
            familiar = _repositorioFamiliar.GetFamiliar(id);
            return Page();
        }
    }
}
