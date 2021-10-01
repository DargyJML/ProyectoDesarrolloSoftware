using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioEquipo
    {
        IEnumerable<Equipo> ListarEquipos();
        bool CrearEquipo(Equipo Equipo);
        bool ActualizarEquipo (Equipo Equipo);
        bool EliminarEquipo(int idEquipo);
        Equipo BuscarEquipo(int idEquipo);
    }
}