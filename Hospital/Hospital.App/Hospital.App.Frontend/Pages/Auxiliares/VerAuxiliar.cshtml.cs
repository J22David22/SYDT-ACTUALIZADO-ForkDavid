using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class VerAuxiliarModel : PageModel
    {
        //Conectarse a la BDs
        private static IRepositorioAuxiliar _repositorioAuxiliar = new RepositorioAuxiliar(new Hospital.App.Persistencia.AppContext());

        // Generamos una variable para mapear que llega del usuario desde la BDs
        [BindProperty]
        public Auxiliar auxiliar { get; set; }

        //constructor
        public VerAuxiliarModel()
        {}

        public ActionResult OnGet(int id)
        {
            auxiliar = _repositorioAuxiliar.GetAuxiliar(id);
            return Page();
        }
    }
}
