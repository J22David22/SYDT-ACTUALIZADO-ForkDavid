using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages.Auxiliares
{
    public class AdminAuxFmliarModel : PageModel
    {
        private  IRepositorioFamiliar _repositorioFamiliar = new RepositorioFamiliar( new Hospital.App.Persistencia.AppContext());

        // Declaro una variable para la lista de Familiars
        public IEnumerable<Familiar> Familiares;

        //Constructor
        public AdminAuxFmliarModel()
        {}

        public void OnGet()
        {
            Familiares = _repositorioFamiliar.GetAllFamiliares();
        }
    }
}
