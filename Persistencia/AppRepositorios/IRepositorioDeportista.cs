using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioDeportista
    {
        IEnumerable<Deportista> ListarDeportistas();
        bool CrearDeportista(Deportista Deportista);
        bool ActualizarDeportista (Deportista Deportista);
        bool EliminarDeportista(int idDeportista);
        Deportista BuscarDeportista(int idDeportista);
    }
}