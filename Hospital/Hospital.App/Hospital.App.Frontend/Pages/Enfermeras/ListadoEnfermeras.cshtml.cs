using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;




namespace Hospital.App.Frontend.Pages
{
    
    public class ListadoEnfermerasModel : PageModel
    {
        // Conexión a la BDs
        private  IRepositorioEnfermera _repositorioEnfermera = new RepositorioEnfermera( new Hospital.App.Persistencia.AppContext());

        // Declaro una variable para la lista de Enfermeras
        public IEnumerable<Enfermera> Enfermeras;

        //Constructor
        public ListadoEnfermerasModel()
        {}

        public void OnGet()
        {
            Enfermeras = _repositorioEnfermera.GetAllEnfermeras();
        }
    }
}

