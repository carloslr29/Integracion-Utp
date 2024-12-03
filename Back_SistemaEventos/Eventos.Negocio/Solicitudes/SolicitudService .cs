using Eventos.Datos.Solicitudes;
using Eventos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Negocio.Solicitudes
{
    public class SolicitudService : ISolicitudService
    {
        private readonly ISolicitudRepository _solicitudRepository;

        public SolicitudService(ISolicitudRepository solicitudRepository)
        {
            _solicitudRepository = solicitudRepository;
        }

        public async Task<Solicitud> RegistrarSolicitud(Solicitud solicitud)
        {
            solicitud.FechaSolicitud = DateTime.Now; // Asignar la fecha de solicitud al momento de crearla
            return await _solicitudRepository.RegistrarSolicitud(solicitud);
        }

        public async Task<IEnumerable<Solicitud>> ObtenerSolicitudes()
        {
            return await _solicitudRepository.ObtenerSolicitudes();
        }

        public async Task<Solicitud> ObtenerSolicitudPorId(int id)
        {
            return await _solicitudRepository.ObtenerSolicitudPorId(id);
        }

        public async Task<Solicitud> ActualizarSolicitud(Solicitud solicitud)
        {
            return await _solicitudRepository.ActualizarSolicitud(solicitud);
        }

        public async Task<IEnumerable<Solicitud>> ObtenerSolicitudesPorFiltro(SolicitudFiltroDto filtros)
        {
            return await _solicitudRepository.ObtenerSolicitudesPorFiltro(filtros);
        }
    }
}
