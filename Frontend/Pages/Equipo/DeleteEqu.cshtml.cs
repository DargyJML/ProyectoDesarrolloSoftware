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
    public class DeleteEquModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        public DeleteEquModel(IRepositorioEquipo repoEquipo)
        {
            this._repoEquipo=repoEquipo;
        }
        [BindProperty]
        public Equipo Equipo{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            Equipo= _repoEquipo.BuscarEquipo(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repoEquipo.EliminarEquipo(Equipo.Id);
             if(funciono)
             {
                return RedirectToPage("./EquIndex");
             }
             else
             {
                 return Page();
             }
             
         }
    }
}
