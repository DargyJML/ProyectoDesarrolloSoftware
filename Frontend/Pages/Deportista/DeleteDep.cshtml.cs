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
    public class DeleteDepModel : PageModel
    {
        private readonly IRepositorioDeportista _repoDeportista;
        public DeleteDepModel(IRepositorioDeportista repoDeportista)
        {
            this._repoDeportista=repoDeportista;
        }
        [BindProperty]
        public Deportista Deportista{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            Deportista= _repoDeportista.BuscarDeportista(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repoDeportista.EliminarDeportista(Deportista.Id);
             if(funciono)
             {
                return RedirectToPage("./DepIndex");
             }
             else
             {
                 return Page();
             }
             
         }
    }
}
