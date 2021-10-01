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
    public class EntIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioEntrenador _repoEntrenador;
        // modelo u objeto para transportar hacia DepIndex.cshtml
        public IEnumerable<Entrenador> Entrenadors {get;set;}

        // constructor
        public EntIndexModel(IRepositorioEntrenador repoEntrenador)
        {
            this._repoEntrenador=repoEntrenador;
        }

        public void OnGet()
        {
            Entrenadors=_repoEntrenador.ListarEntrenadors();
        }
    }
}
