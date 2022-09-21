using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;




namespace Hospital.App.Frontend.Pages
{
    
    public class ListadoPersonasModel : PageModel
    {
        // Conexión a la BDs
        private  IRepositorioPersona _repositorioPersona = new RepositorioPersona( new Hospital.App.Persistencia.AppContext());

        // Declaro una variable para la lista de Personas
        public IEnumerable<Persona> Personas;

        //Constructor
        public ListadoPersonasModel()
        {}

        public void OnGet()
        {
            Personas = _repositorioPersona.GetAllPersonas();
        }
    }
}

