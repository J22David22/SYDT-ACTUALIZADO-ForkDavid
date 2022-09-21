using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;

namespace Hospital.App.Frontend.Pages
{
    public class VerPacienteModel : PageModel
    {
        //Conectarse a la BDs
        private IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente(new Hospital.App.Persistencia.AppContext());

        // Generamos una variable para mapear que llega del usuario desde la BDs
        [BindProperty]
        public Paciente paciente { get; set; }

        //constructor
        public VerPacienteModel()
        {}

        public ActionResult OnGet(int id)
        {
            paciente = _repositorioPaciente.GetPaciente(id);
            return Page();
        }

        public ActionResult OnPost(int id)
        {
            paciente = _repositorioPaciente.GetPaciente(id);
            return Page();
        }
    }
}
