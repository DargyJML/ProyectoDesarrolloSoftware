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
    public class EditModel : PageModel
    {
        private readonly IRepositorioMunicipio _repomunicipio;
        public EditModel(IRepositorioMunicipio repomunicipio)
        {
            this._repomunicipio=repomunicipio;
        }
        [BindProperty]
        public Municipio Municipio{get;set;}

        public ActionResult OnGet(int id)
        {            
            Municipio= _repomunicipio.BuscarMunicipio(id);
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repomunicipio.ActualizarMunicipio(Municipio);
            if(funciono)
            {
                return RedirectToPage("./MIndex");
            }
            else
            {
                ViewData["Mensaje"]="se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}
