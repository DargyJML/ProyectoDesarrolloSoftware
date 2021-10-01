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
    public class DetailsPatroModel : PageModel
    {
        private readonly IRepositorioPatrocinador _repoPatrocinador;
        public DetailsPatroModel(IRepositorioPatrocinador repoPatrocinador)
        {
            this._repoPatrocinador=repoPatrocinador;
        }
        [BindProperty]
        public Patrocinador Patrocinador{get;set;}

        public ActionResult OnGet(int id)
        {
            Patrocinador= _repoPatrocinador.BuscarPatrocinador(id);
            if (Patrocinador==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
