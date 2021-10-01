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
    public class CreateEntModel : PageModel
    {
        //Objeto  para utilizar el repositorios
        private readonly IRepositorioEntrenador _repoEntrenador;
        //propiedad para transportar al cshtml

        [BindProperty]
        public Entrenador Entrenador{get;set;}
        // constructor
        public CreateEntModel(IRepositorioEntrenador repoEntrenador)
        {
            this._repoEntrenador=repoEntrenador;
        }

        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
           bool creado= _repoEntrenador.CrearEntrenador(Entrenador);
           if(creado)
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