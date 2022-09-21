using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class EditarHistoriaClinicaModel : PageModel
    
    {
        private IRepositorioHistoriaClinica _repositorioHistoriaClinica = new RepositorioHistoriaClinica( new Hospital.App.Persistencia.AppContext());
        private IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public HistoriaClinica historiaClinica {get; set;}
        [BindProperty]
        public Paciente paciente {get;set;}

        public int pacienteid {get;set;}
        public int historiaid {get;set;}

        public EditarHistoriaClinicaModel()
        {}

        public ActionResult OnGet(int id)
        {
            paciente=_repositorioPaciente.GetPaciente(id);
            Console.WriteLine("idpa:" + paciente.Id+"idhicli: "+paciente.HistoriaClinicaId);
            historiaClinica=_repositorioHistoriaClinica.GetHistoriaClinica(paciente.HistoriaClinicaId);
            return Page();
            
        }

        public ActionResult OnPost()
        {
            try{
                historiaClinica.PacienteId = paciente.Id;
                Console.WriteLine("idpapost:" + paciente.Id);
                Console.WriteLine("id: "+historiaClinica.Id+" Diagnostico: "+historiaClinica.Diagnostico+ "Entorno: "+historiaClinica.Entorno+"PaciID: "+historiaClinica.PacienteId+" MediID: "+historiaClinica.MedicoId);
                HistoriaClinica historiaClinicaAdicionado = _repositorioHistoriaClinica.UpdateHistoriaClinica(historiaClinica);
                return RedirectToPage("/Auxiliares/AdminAuxiliar");
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
