using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioEquipo:IRepositorioEquipo
    {
        // Atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor
        public RepositorioEquipo(AppContext appContext)
        {
            _appContext=appContext;
        }
        //implementar todos los metodos de la interfaz IRepositorioEquipo

        bool IRepositorioEquipo.CrearEquipo(Equipo Equipo)
        {
           bool creado=false;
           bool ex= Existe(Equipo);
           if(!ex)
           {
                try
                {
                    _appContext.Equipos.Add(Equipo);
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
        bool IRepositorioEquipo.ActualizarEquipo(Equipo Equipo)
        {
           bool actualizado= false;
           var mun=_appContext.Equipos.Find(Equipo.Id);
           if(mun!=null)
           {
               try
               {
                    mun.Nombre=Equipo.Nombre;
                    mun.Disciplina=Equipo.Disciplina;
                    mun.Entrenador=Equipo.Entrenador;
                    mun.PatrocinadorId=Equipo.PatrocinadorId;
                    //abajo dos listas
                    mun.TorneoEquipos=Equipo.TorneoEquipos;
                    mun.Deportistas=Equipo.Deportistas;
                    
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
        bool IRepositorioEquipo.EliminarEquipo(int idEquipo)
        {
            bool eliminado= false;
            var Equipo=_appContext.Equipos.Find(idEquipo);
            if(Equipo!=null)
            {
                try
                {
                     _appContext.Equipos.Remove(Equipo);
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
        Equipo IRepositorioEquipo.BuscarEquipo(int idEquipo)
        {
            Equipo Equipo= _appContext.Equipos.Find(idEquipo);
            return Equipo;
        }

        IEnumerable<Equipo> IRepositorioEquipo.ListarEquipos()
        {
            return _appContext.Equipos;
        }

        bool Existe(Equipo muni)
        {
            bool ex=false;
            var mun=_appContext.Equipos.FirstOrDefault(m=> m.Nombre==muni.Nombre);
            if(mun!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}