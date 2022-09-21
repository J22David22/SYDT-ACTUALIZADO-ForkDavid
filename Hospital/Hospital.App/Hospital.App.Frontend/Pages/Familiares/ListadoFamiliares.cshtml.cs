using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;




namespace Hospital.App.Frontend.Pages
{
    
    public class ListadoFamiliaresModel : PageModel
    {
        // Conexión a la BDs
        private  IRepositorioFamiliar _repositorioFamiliar = new RepositorioFamiliar( new Hospital.App.Persistencia.AppContext());

        // Declaro una variable para la lista de Familiars
        public IEnumerable<Familiar> Familiares;

        //Constructor
        public ListadoFamiliaresModel()
        {}

        public void OnGet()
        {
            Familiares = _repositorioFamiliar.GetAllFamiliares();
        }
    }
}

