using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioEscenario:IRepositorioEscenario
    {
        // Atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor
        public RepositorioEscenario(AppContext appContext)
        {
            _appContext=appContext;
        }
        //implementar todos los metodos de la interfaz IRepositorioEscenario

        bool IRepositorioEscenario.CrearEscenario(Escenario Escenario)
        {
           bool creado=false;
           bool ex= Existe(Escenario);
           if(!ex)
           {
                try
                {
                    _appContext.Escenarios.Add(Escenario);
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
        bool IRepositorioEscenario.ActualizarEscenario(Escenario Escenario)
        {
           bool actualizado= false;
           var mun=_appContext.Escenarios.Find(Escenario.Id);
           if(mun!=null)
           {
               try
               {
                    mun.Nombre=Escenario.Nombre;
                    mun.Direccion=Escenario.Direccion;
                    mun.Telefono=Escenario.Telefono;
                    mun.Horario=Escenario.Horario;
                    mun.CapacidadEspectadores=Escenario.CapacidadEspectadores;
                    mun.TorneoId=Escenario.TorneoId;
                    mun.Arenas=Escenario.Arenas;
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
        bool IRepositorioEscenario.EliminarEscenario(int idEscenario)
        {
            bool eliminado= false;
            var Escenario=_appContext.Escenarios.Find(idEscenario);
            if(Escenario!=null)
            {
                try
                {
                     _appContext.Escenarios.Remove(Escenario);
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
        Escenario IRepositorioEscenario.BuscarEscenario(int idEscenario)
        {
            Escenario Escenario= _appContext.Escenarios.Find(idEscenario);
            return Escenario;
        }

        IEnumerable<Escenario> IRepositorioEscenario.ListarEscenarios()
        {
            return _appContext.Escenarios;
        }

        bool Existe(Escenario muni)
        {
            bool ex=false;
            var mun=_appContext.Escenarios.FirstOrDefault(m=> m.Nombre==muni.Nombre);
            if(mun!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}