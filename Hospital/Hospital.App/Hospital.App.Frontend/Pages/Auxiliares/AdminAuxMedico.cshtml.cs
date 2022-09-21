using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages.Auxiliares
{
    public class AdminAuxMedicoModel : PageModel
    {
        // Conexión a la BDs
        private  IRepositorioMedico _repositorioMedico = new RepositorioMedico( new Hospital.App.Persistencia.AppContext());

        // Declaro una variable para la lista de Medicos
        public IEnumerable<Medico> Medicos;

        //Constructor
        public AdminAuxMedicoModel()
        {}

        public void OnGet()
        {
            Medicos = _repositorioMedico.GetAllMedicos();
        }
    }
}
