using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioTorneo
    {
        IEnumerable<Torneo> ListarTorneos();
        bool CrearTorneo(Torneo Torneo);
        bool ActualizarTorneo (Torneo Torneo);
        bool EliminarTorneo(int idTorneo);
        Torneo BuscarTorneo(int idTorneo);
    }
}