using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioTorneo:IRepositorioTorneo
    {
        // Atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor
        public RepositorioTorneo(AppContext appContext)
        {
            _appContext=appContext;
        }
        //implementar todos los metodos de la interfaz IRepositorioTorneo

        bool IRepositorioTorneo.CrearTorneo(Torneo Torneo)
        {
           bool creado=false;
           bool ex= Existe(Torneo);
           if(!ex)
           {
                try
                {
                    _appContext.Torneos.Add(Torneo);
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
        bool IRepositorioTorneo.ActualizarTorneo(Torneo Torneo)
        {
           bool actualizado= false;
           var mun=_appContext.Torneos.Find(Torneo.Id);
           if(mun!=null)
           {
               try
               {
                    mun.Nombre=Torneo.Nombre;
                    mun.Categoria=Torneo.Categoria;
                    mun.FechaInicio=Torneo.FechaInicio;
                    mun.FechaFin=Torneo.FechaFin;
                    mun.TipoTorneo=Torneo.TipoTorneo;
                    mun.MunicipioId=Torneo.MunicipioId;
                    mun.TorneoEquipos=Torneo.TorneoEquipos;
                    mun.Escenarios=Torneo.Escenarios;
                    mun.Personals=Torneo.Personals;
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
        bool IRepositorioTorneo.EliminarTorneo(int idTorneo)
        {
            bool eliminado= false;
            var Torneo=_appContext.Torneos.Find(idTorneo);
            if(Torneo!=null)
            {
                try
                {
                     _appContext.Torneos.Remove(Torneo);
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
        Torneo IRepositorioTorneo.BuscarTorneo(int idTorneo)
        {
            Torneo Torneo= _appContext.Torneos.Find(idTorneo);
            return Torneo;
        }

        IEnumerable<Torneo> IRepositorioTorneo.ListarTorneos()
        {
            return _appContext.Torneos;
        }

        bool Existe(Torneo muni)
        {
            bool ex=false;
            var mun=_appContext.Torneos.FirstOrDefault(m=> m.Nombre==muni.Nombre);
            if(mun!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}