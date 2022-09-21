using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;




namespace Hospital.App.Frontend.Pages
{
    
    public class ListadoAuxiliaresModel : PageModel
    {
        // Conexión a la BDs
        private  IRepositorioAuxiliar _repositorioAuxiliar = new RepositorioAuxiliar( new Hospital.App.Persistencia.AppContext());

        // Declaro una variable para la lista de Auxiliars
        public IEnumerable<Auxiliar> Auxiliares;

        //Constructor
        public ListadoAuxiliaresModel()
        {}

        public void OnGet()
        {
            Auxiliares = _repositorioAuxiliar.GetAllAuxiliares();
        }
    }
}

