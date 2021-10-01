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
    public class DeletePatroModel : PageModel
    {
        private readonly IRepositorioPatrocinador _repoPatrocinador;
        public DeletePatroModel(IRepositorioPatrocinador repoPatrocinador)
        {
            this._repoPatrocinador=repoPatrocinador;
        }
        [BindProperty]
        public Patrocinador Patrocinador{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            Patrocinador= _repoPatrocinador.BuscarPatrocinador(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repoPatrocinador.EliminarPatrocinador(Patrocinador.Id);
             if(funciono)
             {
                return RedirectToPage("./PatroIndex");
             }
             else
             {
                 return Page();
             }
             
         }
    }
}
