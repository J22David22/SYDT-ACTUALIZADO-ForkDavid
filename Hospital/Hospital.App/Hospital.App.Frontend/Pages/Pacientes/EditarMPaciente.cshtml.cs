using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;


namespace Hospital.App.Frontend.Pages
{
    public class EditarMPacienteModel : PageModel
   {
        private IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new Hospital.App.Persistencia.AppContext());
        private IRepositorioMedico _repositorioMedico = new RepositorioMedico( new Hospital.App.Persistencia.AppContext());
        private IRepositorioEnfermera _repositorioEnfermera = new RepositorioEnfermera( new Hospital.App.Persistencia.AppContext());

        [BindProperty]
        public Paciente paciente {get; set;}
        [BindProperty]
        public Medico medico {get; set;}
        public IEnumerable<Medico> medicos;
        [BindProperty]
        public Enfermera enfermera {get; set;}
        public IEnumerable<Enfermera> enfermeras;

        public EditarMPacienteModel()
        {}

        public ActionResult OnGet(int id)
        {
            medicos = _repositorioMedico.GetAllMedicos();
            enfermeras = _repositorioEnfermera.GetAllEnfermeras();
            paciente = _repositorioPaciente.GetPaciente(id);
            return Page();
        }

        public ActionResult OnPost()
        {
            try{
                var idP=paciente.Id;
                string str=idP.ToString();
                paciente.MedicoId = medico.Id;
                paciente.EnfermeraId = enfermera.Id;
                Console.WriteLine("Medico Id: " + idP);
                Paciente pacienteActualizado = _repositorioPaciente.UpdatePaciente(paciente);
                return Redirect("./VerPaciente?id="+str);
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    
}
}
