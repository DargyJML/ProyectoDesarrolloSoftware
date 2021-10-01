using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioEntrenador:IRepositorioEntrenador
    {
        // Atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor
        public RepositorioEntrenador(AppContext appContext)
        {
            _appContext=appContext;
        }
        //implementar todos los metodos de la interfaz IRepositorioEntrenador

        bool IRepositorioEntrenador.CrearEntrenador(Entrenador Entrenador)
        {
           bool creado=false;
           bool ex= Existe(Entrenador);
           if(!ex)
           {
                try
                {
                    _appContext.Entrenadors.Add(Entrenador);
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
        bool IRepositorioEntrenador.ActualizarEntrenador(Entrenador Entrenador)
        {
           bool actualizado= false;
           var mun=_appContext.Entrenadors.Find(Entrenador.Id);
           if(mun!=null)
           {
               try
               {
                    mun.Nombres=Entrenador.Nombres;
                    mun.Apellidos=Entrenador.Apellidos;
                    mun.Identificacion=Entrenador.Identificacion;
                    mun.Telefono=Entrenador.Telefono;
                    mun.Direccion=Entrenador.Direccion;
                    mun.Email=Entrenador.Email;
                    mun.Genero=Entrenador.Genero;
                    mun.Rh=Entrenador.Rh;
                    mun.FechaNacimiento=Entrenador.FechaNacimiento;
                    mun.EquipoId=Entrenador.EquipoId;
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
        bool IRepositorioEntrenador.EliminarEntrenador(int idEntrenador)
        {
            bool eliminado= false;
            var Entrenador=_appContext.Entrenadors.Find(idEntrenador);
            if(Entrenador!=null)
            {
                try
                {
                     _appContext.Entrenadors.Remove(Entrenador);
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
        Entrenador IRepositorioEntrenador.BuscarEntrenador(int idEntrenador)
        {
            Entrenador Entrenador= _appContext.Entrenadors.Find(idEntrenador);
            return Entrenador;
        }

        IEnumerable<Entrenador> IRepositorioEntrenador.ListarEntrenadors()
        {
            return _appContext.Entrenadors;
        }

        bool Existe(Entrenador muni)
        {
            bool ex=false;
            var mun=_appContext.Entrenadors.FirstOrDefault(m=> m.Nombres==muni.Nombres);
            if(mun!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}