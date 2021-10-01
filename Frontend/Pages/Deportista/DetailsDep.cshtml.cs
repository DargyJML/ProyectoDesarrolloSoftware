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
    public class DetailsDepModel : PageModel
    {
        private readonly IRepositorioDeportista _repoDeportista;
        public DetailsDepModel(IRepositorioDeportista repoDeportista)
        {
            this._repoDeportista=repoDeportista;
        }
        [BindProperty]
        public Deportista Deportista{get;set;}

        public ActionResult OnGet(int id)
        {
            Deportista= _repoDeportista.BuscarDeportista(id);
            if (Deportista==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
