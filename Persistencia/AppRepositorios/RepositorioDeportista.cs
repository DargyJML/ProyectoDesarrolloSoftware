using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioDeportista:IRepositorioDeportista
    {
        // Atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor
        public RepositorioDeportista(AppContext appContext)
        {
            _appContext=appContext;
        }
        //implementar todos los metodos de la interfaz IRepositorioDeportista

        bool IRepositorioDeportista.CrearDeportista(Deportista Deportista)
        {
           bool creado=false;
           bool ex= Existe(Deportista);
           if(!ex)
           {
                try
                {
                    _appContext.Deportistas.Add(Deportista);
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
        bool IRepositorioDeportista.ActualizarDeportista(Deportista Deportista)
        {
           bool actualizado= false;
           var mun=_appContext.Deportistas.Find(Deportista.Id);
           if(mun!=null)
           {
               try
               {
                    mun.Nombres=Deportista.Nombres;
                    mun.Apellidos=Deportista.Apellidos;
                    mun.Identificacion=Deportista.Identificacion;
                    mun.Telefono=Deportista.Telefono;
                    mun.Direccion=Deportista.Direccion;
                    mun.Email=Deportista.Email;
                    mun.Genero=Deportista.Genero;
                    mun.Rh=Deportista.Rh;
                    mun.FechaNacimiento=Deportista.FechaNacimiento;
                    mun.EquipoId=Deportista.EquipoId;
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
        bool IRepositorioDeportista.EliminarDeportista(int idDeportista)
        {
            bool eliminado= false;
            var Deportista=_appContext.Deportistas.Find(idDeportista);
            if(Deportista!=null)
            {
                try
                {
                     _appContext.Deportistas.Remove(Deportista);
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
        Deportista IRepositorioDeportista.BuscarDeportista(int idDeportista)
        {
            Deportista Deportista= _appContext.Deportistas.Find(idDeportista);
            return Deportista;
        }

        IEnumerable<Deportista> IRepositorioDeportista.ListarDeportistas()
        {
            return _appContext.Deportistas;
        }

        bool Existe(Deportista muni)
        {
            bool ex=false;
            var mun=_appContext.Deportistas.FirstOrDefault(m=> m.Nombres==muni.Nombres);
            if(mun!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}