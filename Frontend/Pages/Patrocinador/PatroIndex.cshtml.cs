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
    public class PatroIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioPatrocinador _repoPatrocinador;
        // modelo u objeto para transportar hacia DepIndex.cshtml
        public IEnumerable<Patrocinador> Patrocinadors {get;set;}

        // constructor
        public PatroIndexModel(IRepositorioPatrocinador repoPatrocinador)
        {
            this._repoPatrocinador=repoPatrocinador;
        }

        public void OnGet()
        {
            Patrocinadors=_repoPatrocinador.ListarPatrocinadors();
        }
    }
}
