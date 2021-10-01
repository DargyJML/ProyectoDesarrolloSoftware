using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioPersonal:IRepositorioPersonal
    {
        // Atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor
        public RepositorioPersonal(AppContext appContext)
        {
            _appContext=appContext;
        }
        //implementar todos los metodos de la interfaz IRepositorioPersonal

        bool IRepositorioPersonal.CrearPersonal(Personal Personal)
        {
           bool creado=false;
           bool ex= Existe(Personal);
           if(!ex)
           {
                try
                {
                    _appContext.Personals.Add(Personal);
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
        bool IRepositorioPersonal.ActualizarPersonal(Personal Personal)
        {
           bool actualizado= false;
           var mun=_appContext.Personals.Find(Personal.Id);
           if(mun!=null)
           {
               try
               {
                    mun.Nombres=Personal.Nombres;
                    mun.Apellidos=Personal.Apellidos;
                    mun.Identificacion=Personal.Identificacion;
                    mun.Labor=Personal.Labor;
                    mun.EntidadResponsable=Personal.EntidadResponsable;
                    mun.Telefono=Personal.Telefono;
                    mun.Direccion=Personal.Direccion;
                    mun.Email=Personal.Email;
                    mun.Rh=Personal.Rh;
                    mun.FechaNacimiento=Personal.FechaNacimiento;
                    mun.TorneoId=Personal.TorneoId;
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
        bool IRepositorioPersonal.EliminarPersonal(int idPersonal)
        {
            bool eliminado= false;
            var Personal=_appContext.Personals.Find(idPersonal);
            if(Personal!=null)
            {
                try
                {
                     _appContext.Personals.Remove(Personal);
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
        Personal IRepositorioPersonal.BuscarPersonal(int idPersonal)
        {
            Personal Personal= _appContext.Personals.Find(idPersonal);
            return Personal;
        }

        IEnumerable<Personal> IRepositorioPersonal.ListarPersonals()
        {
            return _appContext.Personals;
        }

        bool Existe(Personal muni)
        {
            bool ex=false;
            var mun=_appContext.Personals.FirstOrDefault(m=> m.Nombres==muni.Nombres);
            if(mun!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}