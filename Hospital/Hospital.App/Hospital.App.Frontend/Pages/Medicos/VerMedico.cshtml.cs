using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class VerMedicoModel : PageModel
    {
        //Conectarse a la BDs
        private static IRepositorioMedico _repositorioMedico = new RepositorioMedico(new Hospital.App.Persistencia.AppContext());

        // Generamos una variable para mapear que llega del usuario desde la BDs
        [BindProperty]
        public Medico medico { get; set; }

        //constructor
        public VerMedicoModel()
        {}

        public ActionResult OnGet(int id)
        {
            medico = _repositorioMedico.GetMedico(id);
            return Page();
        }
    }
}