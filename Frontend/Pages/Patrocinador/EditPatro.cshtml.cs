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
    public class EditPatroModel : PageModel
    {
        private readonly IRepositorioPatrocinador _repoPatrocinador;
        public EditPatroModel(IRepositorioPatrocinador repoPatrocinador)
        {
            this._repoPatrocinador=repoPatrocinador;
        }
        [BindProperty]
        public Patrocinador Patrocinador{get;set;}

        public ActionResult OnGet(int id)
        {            
            Patrocinador= _repoPatrocinador.BuscarPatrocinador(id);
            return Page();
        }

         public ActionResult OnPost()
         {
                       
            bool funciono=_repoPatrocinador.ActualizarPatrocinador(Patrocinador);
            if(funciono)
            {
                return RedirectToPage("./PatroIndex");
            }
            else
            {
                ViewData["Mensaje"]="se ha presentado un error...";
                return Page();
            }             
            
         }
    }
}
