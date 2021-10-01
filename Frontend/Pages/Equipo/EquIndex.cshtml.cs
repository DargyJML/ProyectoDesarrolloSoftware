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
    public class EquIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioEquipo _repoEquipo;
        // modelo u objeto para transportar hacia DepIndex.cshtml
        public IEnumerable<Equipo> Equipos {get;set;}

        // constructor
        public EquIndexModel(IRepositorioEquipo repoEquipo)
        {
            this._repoEquipo=repoEquipo;
        }

        public void OnGet()
        {
            Equipos=_repoEquipo.ListarEquipos();
        }
    }
}
