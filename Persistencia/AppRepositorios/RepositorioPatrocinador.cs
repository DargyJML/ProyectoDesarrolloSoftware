using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia
{
    public class RepositorioPatrocinador:IRepositorioPatrocinador
    {
        // Atributos
        private readonly AppContext _appContext;

        //Metodos
        //Constructor
        public RepositorioPatrocinador(AppContext appContext)
        {
            _appContext=appContext;
        }
        //implementar todos los metodos de la interfaz IRepositorioPatrocinador

        bool IRepositorioPatrocinador.CrearPatrocinador(Patrocinador Patrocinador)
        {
           bool creado=false;
           bool ex= Existe(Patrocinador);
           if(!ex)
           {
                try
                {
                    _appContext.Patrocinadors.Add(Patrocinador);
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
        bool IRepositorioPatrocinador.ActualizarPatrocinador(Patrocinador Patrocinador)
        {
           bool actualizado= false;
           var mun=_appContext.Patrocinadors.Find(Patrocinador.Id);
           if(mun!=null)
           {
               try
               {
                    mun.Nombres=Patrocinador.Nombres;
                    mun.Apellidos=Patrocinador.Apellidos;
                    mun.Identificacion=Patrocinador.Identificacion;
                    mun.TipoPersona=Patrocinador.TipoPersona;
                    mun.Telefono=Patrocinador.Telefono;
                    mun.Direccion=Patrocinador.Direccion;
                    mun.Email=Patrocinador.Email;
                   // mun.Equipos=Patrocinador.Equipos;
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
        bool IRepositorioPatrocinador.EliminarPatrocinador(int idPatrocinador)
        {
            bool eliminado= false;
            var Patrocinador=_appContext.Patrocinadors.Find(idPatrocinador);
            if(Patrocinador!=null)
            {
                try
                {
                     _appContext.Patrocinadors.Remove(Patrocinador);
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
        Patrocinador IRepositorioPatrocinador.BuscarPatrocinador(int idPatrocinador)
        {
            Patrocinador Patrocinador= _appContext.Patrocinadors.Find(idPatrocinador);
            return Patrocinador;
        }

        IEnumerable<Patrocinador> IRepositorioPatrocinador.ListarPatrocinadors()
        {
            return _appContext.Patrocinadors;
        }

        bool Existe(Patrocinador muni)
        {
            bool ex=false;
            var mun=_appContext.Patrocinadors.FirstOrDefault(m=> m.Nombres==muni.Nombres);
            if(mun!=null)
            {
                ex=true;
            }
            return ex;
        }

    }
}