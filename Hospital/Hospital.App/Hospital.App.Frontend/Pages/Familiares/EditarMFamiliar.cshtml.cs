using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hospital.App.Persistencia;
using Hospital.App.Dominio;


namespace Hospital.App.Frontend.Pages
{
    public class EditarMFamiliarModel : PageModel
   {
        private IRepositorioFamiliar _repositorioFamiliar = new RepositorioFamiliar( new Hospital.App.Persistencia.AppContext());
        
        [BindProperty]
        public Familiar familiar {get; set;}
        

        public EditarMFamiliarModel()
        {}

        public ActionResult OnGet(int id)
        {
            familiar = _repositorioFamiliar.GetFamiliar(id);
            return Page();
        }

        public ActionResult OnPost()
        {
            try{
                var idP=familiar.Id;
                string str=idP.ToString();
                Familiar familiarActualizado = _repositorioFamiliar.UpdateFamiliar(familiar);
                return Redirect("./VerFamiliar?id="+str);
            }catch(System.Exception e)
            {
                ViewData["Error"] = "Error: " + e.Message;
                return Page();
            }
        }
    
}
}
