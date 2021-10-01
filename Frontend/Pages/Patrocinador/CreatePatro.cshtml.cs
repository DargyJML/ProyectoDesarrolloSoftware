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
    public class CreatePatroModel : PageModel
    {
        //Objeto  para utilizar el repositorios
        private readonly IRepositorioPatrocinador _repoPatrocinador;
        //propiedad para transportar al cshtml

        [BindProperty]
        public Patrocinador Patrocinador{get;set;}
        // constructor
        public CreatePatroModel(IRepositorioPatrocinador repoPatrocinador)
        {
            this._repoPatrocinador=repoPatrocinador;
        }

        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
           bool creado= _repoPatrocinador.CrearPatrocinador(Patrocinador);
           if(creado)
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