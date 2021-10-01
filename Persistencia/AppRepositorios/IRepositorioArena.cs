using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioArena
    {
        IEnumerable<Arena> ListarArenas();
        bool CrearArena(Arena Arena);
        bool ActualizarArena (Arena Arena);
        bool EliminarArena(int idArena);
        Arena BuscarArena(int idArena);
    }
}