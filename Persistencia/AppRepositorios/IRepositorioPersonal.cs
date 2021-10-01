using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioPersonal
    {
        IEnumerable<Personal> ListarPersonals();
        bool CrearPersonal(Personal Personal);
        bool ActualizarPersonal (Personal Personal);
        bool EliminarPersonal(int idPersonal);
        Personal BuscarPersonal(int idPersonal);
    }
}