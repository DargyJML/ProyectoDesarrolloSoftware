using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioEscenario
    {
        IEnumerable<Escenario> ListarEscenarios();
        bool CrearEscenario(Escenario Escenario);
        bool ActualizarEscenario (Escenario Escenario);
        bool EliminarEscenario(int idEscenario);
        Escenario BuscarEscenario(int idEscenario);
    }
}