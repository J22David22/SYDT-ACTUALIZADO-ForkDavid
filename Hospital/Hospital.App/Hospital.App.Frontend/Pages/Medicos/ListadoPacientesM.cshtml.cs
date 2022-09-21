using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;




namespace Hospital.App.Frontend.Pages
{
    
    public class ListadoPacientesMModel : PageModel
    {
        // Conexión a la BDs
        private  IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new Hospital.App.Persistencia.AppContext());
        private  IRepositorioMedico _repositorioMedico = new RepositorioMedico( new Hospital.App.Persistencia.AppContext());
        // Declaro una variable para la lista de PacientesM
        public IEnumerable<Paciente> PacientesM;
        public Medico medico{ get; set; }
        

        //Constructor
        public ListadoPacientesMModel()
        {}

        public void OnGet(int id)
        {
            PacientesM = _repositorioPaciente.GetAllPacientes();
            medico = _repositorioMedico.GetMedico(id);
            PacientesM = PacientesM.Where(p => p.MedicoId == id);
        }
    }
}

