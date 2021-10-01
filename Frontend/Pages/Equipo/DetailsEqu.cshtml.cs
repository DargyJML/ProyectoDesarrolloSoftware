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
    public class DetailsEquModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        public DetailsEquModel(IRepositorioEquipo repoEquipo)
        {
            this._repoEquipo=repoEquipo;
        }
        [BindProperty]
        public Equipo Equipo{get;set;}

        public ActionResult OnGet(int id)
        {
            Equipo= _repoEquipo.BuscarEquipo(id);
            if (Equipo==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
