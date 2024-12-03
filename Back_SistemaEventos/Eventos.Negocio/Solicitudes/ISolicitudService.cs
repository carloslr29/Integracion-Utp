using Eventos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Negocio.Solicitudes
{
    public interface ISolicitudService
    {
        Task<Solicitud> RegistrarSolicitud(Solicitud solicitud);
        Task<IEnumerable<Solicitud>> ObtenerSolicitudes();
        Task<Solicitud> ObtenerSolicitudPorId(int id);
        Task<Solicitud> ActualizarSolicitud(Solicitud solicitud);
        Task<IEnumerable<Solicitud>> ObtenerSolicitudesPorFiltro(SolicitudFiltroDto filtros);
    }
}
