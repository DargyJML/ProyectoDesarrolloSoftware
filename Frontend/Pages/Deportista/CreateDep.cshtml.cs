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
    public class CreateDepModel : PageModel
    {
        //Objeto  para utilizar el repositorios
        private readonly IRepositorioDeportista _repoDeportista;
        //propiedad para transportar al cshtml

        [BindProperty]
        public Deportista Deportista{get;set;}
        // constructor
        public CreateDepModel(IRepositorioDeportista repoDeportista)
        {
            this._repoDeportista=repoDeportista;
        }

        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
           bool creado= _repoDeportista.CrearDeportista(Deportista);
           if(creado)
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