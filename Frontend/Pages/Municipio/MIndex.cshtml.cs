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
    public class MIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioMunicipio _repomunicipio;
        // modelo u objeto para transportar hacia MIndex.cshtml
        public IEnumerable<Municipio> Municipios {get;set;}

        // constructor
        public MIndexModel(IRepositorioMunicipio repomunicipio)
        {
            this._repomunicipio=repomunicipio;
        }

        public void OnGet()
        {
            Municipios=_repomunicipio.ListarMunicipios();
        }
    }
}
