using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioArena:IRepositorioArena
    {
        // Atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor
        public RepositorioArena(AppContext appContext)
        {
            _appContext=appContext;
        }
        //implementar todos los metodos de la interfaz IRepositorioArena

        bool IRepositorioArena.CrearArena(Arena Arena)
        {
           bool creado=false;
           bool ex= Existe(Arena);
           if(!ex)
           {
                try
                {
                    _appContext.Arenas.Add(Arena);
                    _appContext.SaveChanges();
                    creado=true;
                }
                catch (System.Exception)
                {
                return creado;
                    //throw;
                }
           }          
           return creado;
        }
        bool IRepositorioArena.ActualizarArena(Arena Arena)
        {
           bool actualizado= false;
           var mun=_appContext.Arenas.Find(Arena.Id);
           if(mun!=null)
           {
               try
               {
                    mun.Nombre=Arena.Nombre;
                    mun.Disciplina=Arena.Disciplina;
                    mun.Estado=Arena.Estado;
                    mun.CapacidadEspectadores=Arena.CapacidadEspectadores;
                    mun.Dimensiones=Arena.Dimensiones;
                    mun.EscenarioId=Arena.EscenarioId;
                    _appContext.SaveChanges();
                    actualizado=true;
               }
               catch (System.Exception)
               {
                   
                   return actualizado;
               }
           }
           return actualizado;
        }
        bool IRepositorioArena.EliminarArena(int idArena)
        {
            bool eliminado= false;
            var Arena=_appContext.Arenas.Find(idArena);
            if(Arena!=null)
            {
                try
                {
                     _appContext.Arenas.Remove(Arena);
                     _appContext.SaveChanges();
                     eliminado=true;
                }
                catch (System.Exception)
                {                    
                    return eliminado;
                }
            }
            return eliminado;
        }
        Arena IRepositorioArena.BuscarArena(int idArena)
        {
            Arena Arena= _appContext.Arenas.Find(idArena);
            return Arena;
        }

        IEnumerable<Arena> IRepositorioArena.ListarArenas()
        {
            return _appContext.Arenas;
        }

        bool Existe(Arena muni)
        {
            bool ex=false;
            var mun=_appContext.Arenas.FirstOrDefault(m=> m.Nombre==muni.Nombre);
            if(mun!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}