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
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioMunicipio _repomunicipio;
        public DetailsModel(IRepositorioMunicipio repomunicipio)
        {
            this._repomunicipio=repomunicipio;
        }
        [BindProperty]
        public Municipio Municipio{get;set;}

        public ActionResult OnGet(int id)
        {
            Municipio= _repomunicipio.BuscarMunicipio(id);
            if (Municipio==null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
