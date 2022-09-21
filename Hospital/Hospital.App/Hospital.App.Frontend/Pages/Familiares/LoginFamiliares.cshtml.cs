using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class LoginFamiliaresModel : PageModel
    {
        private IRepositorioFamiliar _repositorioFamiliar = new RepositorioFamiliar( new Hospital.App.Persistencia.AppContext());

        public LoginFamiliaresModel()
        {

        }
        public Familiar familiar { get; set; }
        public IEnumerable<Familiar> familiares;
        public string telefono {get;set;}
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost(string telefono)
        {
            try{
                // Guardamos la lista de todos los Familiares
                familiares=_repositorioFamiliar.GetAllFamiliares();
                Console.WriteLine("tel: "+ telefono);
                
                if (familiares != null)  
                {
                  
                        familiar = familiares.SingleOrDefault(s => s.NumeroTelefono.Contains(telefono)); 

                        if (familiar.NumeroTelefono==telefono )
                        {
                            var idFamiliarEncontrado = familiar.Id;
                            string str=idFamiliarEncontrado.ToString();
                            Console.WriteLine("Encontrado: " + familiar.Nombre);
                            return Redirect("./VerFamiliar?id="+str);
                        }
                        else{
                            return Page();
                        }
                        
                
                }
                //paciente = _repositorioPaciente.GetPaciente(id);
                
                return Page();
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
