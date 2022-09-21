using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;




namespace Hospital.App.Frontend.Pages
{
    
    public class ListadoMedicosModel : PageModel
    {
        // Conexión a la BDs
        private  IRepositorioMedico _repositorioMedico = new RepositorioMedico( new Hospital.App.Persistencia.AppContext());

        // Declaro una variable para la lista de Medicos
        public IEnumerable<Medico> Medicos;

        //Constructor
        public ListadoMedicosModel()
        {}

        public void OnGet()
        {
            Medicos = _repositorioMedico.GetAllMedicos();
        }
    }
}

