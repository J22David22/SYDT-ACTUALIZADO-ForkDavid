using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class LoginEnfermerasModel : PageModel
    {
        private static IRepositorioEnfermera _repositorioEnfermera = new RepositorioEnfermera( new Hospital.App.Persistencia.AppContext());

        public LoginEnfermerasModel()
        {

        }
        public Enfermera enfermera { get; set; }
        public IEnumerable<Enfermera> enfermeras;
        public string telefono {get;set;}
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost(string telefono)
        {
            try{
                // Guardamos la lista de todos los enfermeras
                enfermeras=_repositorioEnfermera.GetAllEnfermeras();
                Console.WriteLine("tel: "+ telefono );
                
                if (enfermeras != null)  
                {
                  
                        enfermera = enfermeras.SingleOrDefault(s => s.NumeroTelefono.Contains(telefono)); 

                        if (enfermera.NumeroTelefono==telefono )
                        {
                            var idEnfermeraEncontrado = enfermera.Id;
                            string str=idEnfermeraEncontrado.ToString();
                            Console.WriteLine("Encontrado: " + enfermera.Nombre);
                            return Redirect("./VerEnfermera?id="+str);
                        }
                        else{
                            return Page();
                        }
                
                }
                //medico = _repositorioMedico.GetMedico(id);
                /*if(medico.NumeroTelefono==telefono)
                {
                    return RedirectToPage("/Medicos/ListadoMedicos");
                }
                else
                {
                    return RedirectToPage("/Index");
                }

                */

                        enfermera = enfermeras.SingleOrDefault(s => s.NumeroTelefono.Contains(telefono)); 

                        if (enfermera.NumeroTelefono==telefono )
                        {
                            var idEnfermeraEncontrado = enfermera.Id;
                            string str=idEnfermeraEncontrado.ToString();
                            Console.WriteLine("Encontrado: " + enfermera.Nombre);
                            return Redirect("./VerEnfermera?id="+str);
                        }
                        else{
                            return Page();
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
