using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioTorneoEquipo
    {
        IEnumerable<TorneoEquipo> ListarTorneoEquipos();
        bool CrearTorneoEquipo(TorneoEquipo TorneoEquipo);
        bool ActualizarTorneoEquipo (TorneoEquipo TorneoEquipo);
        bool EliminarTorneoEquipo(int idTorneoEquipo);
        TorneoEquipo BuscarTorneoEquipo(int idTorneoEquipo);
    }
}