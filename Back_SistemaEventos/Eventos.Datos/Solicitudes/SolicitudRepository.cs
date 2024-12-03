using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Datos.Solicitudes
{
    public class SolicitudRepository : ISolicitudRepository
    {
        private readonly ConexionBD _context;

        public SolicitudRepository(ConexionBD context)
        {
            _context = context;
        }

        public async Task<Solicitud> RegistrarSolicitud(Solicitud solicitud)
        {
            _context.Solicitudes.Add(solicitud);
            await _context.SaveChangesAsync();
            return solicitud;
        }

        public async Task<IEnumerable<Solicitud>> ObtenerSolicitudes()
        {
            return await _context.Solicitudes.ToListAsync();
        }

        public async Task<Solicitud> ObtenerSolicitudPorId(int id)
        {
            return await _context.Solicitudes.FindAsync(id);
        }

        public async Task<Solicitud> ActualizarSolicitud(Solicitud solicitud)
        {
            _context.Solicitudes.Update(solicitud);
            await _context.SaveChangesAsync();
            return solicitud;
        }

        public async Task<IEnumerable<Solicitud>> ObtenerSolicitudesPorFiltro(SolicitudFiltroDto filtros)
        {
            var query = _context.Solicitudes.AsQueryable(); // Consulta sobre la tabla 'Solicitudes'

            // Filtrar por fecha de inicio (FechaSolicitud >= FechaInicio) si se especifica
            if (filtros.FechaInicio.HasValue)
            {
                query = query.Where(s => s.FechaSolicitud >= filtros.FechaInicio.Value);
            }

            // Filtrar por fecha de fin (FechaSolicitud <= FechaFin) si se especifica
            if (filtros.FechaFin.HasValue)
            {
                query = query.Where(s => s.FechaSolicitud <= filtros.FechaFin.Value);
            }

            // Filtrar por estado si se especifica
            //if (!string.IsNullOrEmpty(filtros.Estado))
            //{
            //    query = query.Where(s => s.Estado == filtros.Estado);
            //}
            // Filtrar por estado si no es "0"
            if (!string.IsNullOrEmpty(filtros.Estado) && filtros.Estado != "0")
            {
                query = query.Where(s => s.Estado == filtros.Estado);
            }

            // Ejecutar la consulta asincrónica y devolver los resultados
            return await query.ToListAsync();
        }
    }
}
