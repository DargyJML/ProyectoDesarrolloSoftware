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
    public class DepIndexModel : PageModel
    {
        //Crear un objeto para hacer uso de los repositorios
        private readonly IRepositorioDeportista _repoDeportista;
        // modelo u objeto para transportar hacia DepIndex.cshtml
        public IEnumerable<Deportista> Deportistas {get;set;}

        // constructor
        public DepIndexModel(IRepositorioDeportista repoDeportista)
        {
            this._repoDeportista=repoDeportista;
        }

        public void OnGet()
        {
            Deportistas=_repoDeportista.ListarDeportistas();
        }
    }
}
