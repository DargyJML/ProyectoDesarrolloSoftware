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
    public class DeleteEntModel : PageModel
    {
        private readonly IRepositorioEntrenador _repoEntrenador;
        public DeleteEntModel(IRepositorioEntrenador repoEntrenador)
        {
            this._repoEntrenador=repoEntrenador;
        }
        [BindProperty]
        public Entrenador Entrenador{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            Entrenador= _repoEntrenador.BuscarEntrenador(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repoEntrenador.EliminarEntrenador(Entrenador.Id);
             if(funciono)
             {
                return RedirectToPage("./EntIndex");
             }
             else
             {
                 return Page();
             }
             
         }
    }
}
