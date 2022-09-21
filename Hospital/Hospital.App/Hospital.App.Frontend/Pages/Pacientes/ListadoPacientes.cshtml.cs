using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;




namespace Hospital.App.Frontend.Pages
{
    
    public class ListadoPacientesModel : PageModel
    {
        // Conexión a la BDs
        private  IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new Hospital.App.Persistencia.AppContext());
        //private  IRepositorioMedico _repositorioMedico = new RepositorioMedico( new Hospital.App.Persistencia.AppContext());

    
        // Declaro una variable para la lista de Pacientes
        public IEnumerable<Paciente> Pacientes;
        

        //Constructor
        public ListadoPacientesModel()
        {}

        public void OnGet()
        {
            Pacientes = _repositorioPaciente.GetAllPacientes();
            
        }
    }
}

