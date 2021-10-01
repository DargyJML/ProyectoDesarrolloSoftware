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
    public class EditEntModel : PageModel
    {
        
        private readonly IRepositorioEntrenador _repoEntrenador;
        public EditEntModel(IRepositorioEntrenador repoEntrenador)
        {
            this._repoEntrenador=repoEntrenador;
        }
        [BindProperty]
        public Entrenador Entrenador{get;set;}

        public ActionResult OnGet(int id)
        {            
            Entrenador= _repoEntrenador.BuscarEntrenador(id);
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repoEntrenador.ActualizarEntrenador(Entrenador);
            if(funciono)
            {
                return RedirectToPage("./EntIndex");
            }
            else
            {
                ViewData["Mensaje"]="se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}
