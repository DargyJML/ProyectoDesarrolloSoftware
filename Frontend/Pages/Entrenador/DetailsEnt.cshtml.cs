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
    public class DetailsEntModel : PageModel
    {
        
        private readonly IRepositorioEntrenador _repoEntrenador;
        public DetailsEntModel(IRepositorioEntrenador repoEntrenador)
        {
            this._repoEntrenador=repoEntrenador;
        }
        [BindProperty]
        public Entrenador Entrenador{get;set;}

        public ActionResult OnGet(int id)
        {
            Entrenador= _repoEntrenador.BuscarEntrenador(id);
            if (Entrenador==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
