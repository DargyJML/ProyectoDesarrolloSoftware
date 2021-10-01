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
    public class DeleteModel : PageModel
    {
        private readonly IRepositorioMunicipio _repomunicipio;
        public DeleteModel(IRepositorioMunicipio repomunicipio)
        {
            this._repomunicipio=repomunicipio;
        }
        [BindProperty]
        public Municipio Municipio{get;set;}

        public ActionResult OnGet(int id)
        {
            ViewData["Mensaje"]="Esta seguro de eliminar el registro?";
            Municipio= _repomunicipio.BuscarMunicipio(id);
            return Page();
        }

         public ActionResult OnPost()
         {
             bool funciono=_repomunicipio.EliminarMunicipio(Municipio.Id);
             if(funciono)
             {
                return RedirectToPage("./MIndex");
             }
             else
             {
                 return Page();
             }
             
         }
    }
}
