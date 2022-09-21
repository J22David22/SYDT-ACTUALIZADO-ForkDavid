using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Dominio;
using Hospital.App.Persistencia;

namespace Hospital.App.Frontend.Pages
{
    public class LoginPacientesModel : PageModel
    {
        private static IRepositorioPaciente _repositorioPaciente = new RepositorioPaciente( new Hospital.App.Persistencia.AppContext());

        public LoginPacientesModel()
        {

        }
        public Paciente paciente { get; set; }
        public IEnumerable<Paciente> pacientes;
        public string telefono {get;set;}
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost(string telefono)
        {
            try{
                // Guardamos la lista de todos los pacientes
                pacientes=_repositorioPaciente.GetAllPacientes();
                Console.WriteLine("tel: "+ telefono);
                
                if (pacientes != null)  
                {
                        Console.WriteLine("Entró al condicional: "+ telefono);
                        paciente = pacientes.SingleOrDefault(s => s.NumeroTelefono == telefono); 
                        Console.WriteLine("encontrar a: "+ paciente.Nombre);
                        if (paciente.NumeroTelefono==telefono )
                        {
                            var idPacienteEncontrado = paciente.Id;
                            string str=idPacienteEncontrado.ToString();
                            Console.WriteLine("Encontrado: " + paciente.Nombre);
                            return Redirect("./VerPaciente?id="+str);
                        }
                        else{
                            return Page();
                        }
                
                }
                //paciente = _repositorioPaciente.GetPaciente(id);
                /*if(paciente.NumeroTelefono==telefono)
                {
                    return RedirectToPage("/Pacientes/ListadoPacientes");
                }
                else
                {
                    return RedirectToPage("/Index");
                }

                */
                return Page();
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    }
}
