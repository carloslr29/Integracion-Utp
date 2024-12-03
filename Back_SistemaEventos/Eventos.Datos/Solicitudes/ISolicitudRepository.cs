using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos.Entidades;

namespace Eventos.Datos.Solicitudes
{
    public interface ISolicitudRepository
    {
        Task<Solicitud> RegistrarSolicitud(Solicitud solicitud);
        Task<IEnumerable<Solicitud>> ObtenerSolicitudes();
        Task<Solicitud> ObtenerSolicitudPorId(int id);
        Task<Solicitud> ActualizarSolicitud(Solicitud solicitud);
        Task<IEnumerable<Solicitud>> ObtenerSolicitudesPorFiltro(SolicitudFiltroDto filtros);
    }
}
