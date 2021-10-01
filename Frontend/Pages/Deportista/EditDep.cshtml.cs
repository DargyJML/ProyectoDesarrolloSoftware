using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Frontend.Pages
{
    public class EditDepModel : PageModel
    {
        private readonly IRepositorioDeportista _repoDeportista;
        public EditDepModel(IRepositorioDeportista repoDeportista)
        {
            this._repoDeportista=repoDeportista;
        }
        [BindProperty]
        public Deportista Deportista{get;set;}

        public ActionResult OnGet(int id)
        {            
            Deportista= _repoDeportista.BuscarDeportista(id);
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repoDeportista.ActualizarDeportista(Deportista);
            if(funciono)
            {
                return RedirectToPage("./DepIndex");
            }
            else
            {
                ViewData["Mensaje"]="se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}
