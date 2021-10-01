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
    public class EditEquModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        public EditEquModel(IRepositorioEquipo repoEquipo)
        {
            this._repoEquipo=repoEquipo;
        }
        [BindProperty]
        public Equipo Equipo{get;set;}

        public ActionResult OnGet(int id)
        {            
            Equipo= _repoEquipo.BuscarEquipo(id);
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repoEquipo.ActualizarEquipo(Equipo);
            if(funciono)
            {
                return RedirectToPage("./EquIndex");
            }
            else
            {
                ViewData["Mensaje"]="se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}
