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
    public class CreateEquModel : PageModel
    {
        //Objeto  para utilizar el repositorios
        private readonly IRepositorioEquipo _repoEquipo;
        //propiedad para transportar al cshtml

        [BindProperty]
        public Equipo Equipo{get;set;}
        // constructor
        public CreateEquModel(IRepositorioEquipo repoEquipo)
        {
            this._repoEquipo=repoEquipo;
        }

        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
           bool creado= _repoEquipo.CrearEquipo(Equipo);
           if(creado)
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