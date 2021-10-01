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
    public class CreateModel : PageModel
    {
        //Objeto  para utilizar el repositorios
        private readonly IRepositorioMunicipio _repomunicipio;
        //propiedad para transportar al cshtml

        [BindProperty]
        public Municipio Municipio{get;set;}
        // constructor
        public CreateModel(IRepositorioMunicipio repomunicipio)
        {
            this._repomunicipio=repomunicipio;
        }

        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
           bool creado= _repomunicipio.CrearMunicipio(Municipio);
           if(creado)
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