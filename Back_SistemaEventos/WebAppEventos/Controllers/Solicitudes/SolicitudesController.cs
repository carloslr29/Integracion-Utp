using Eventos.Entidades;
using Eventos.Negocio.Solicitudes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppEventos.Controllers.Solicitudes
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesController : Controller
    {
        private readonly ISolicitudService _solicitudService;

        public SolicitudesController(ISolicitudService solicitudService)
        {
            _solicitudService = solicitudService;
        }

        // POST: api/Solicitudes
        [HttpPost]
        public async Task<ActionResult<Solicitud>> PostSolicitud(Solicitud solicitud)
        {
            var nuevaSolicitud = await _solicitudService.RegistrarSolicitud(solicitud);
            return CreatedAtAction(nameof(GetSolicitud), new { id = nuevaSolicitud.SolicitudID }, nuevaSolicitud);
        }

        // GET: api/Solicitudes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solicitud>>> GetSolicitudes()
        {
            var solicitudes = await _solicitudService.ObtenerSolicitudes();
            return Ok(solicitudes);
        }

        // GET: api/Solicitudes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitud>> GetSolicitud(int id)
        {
            var solicitud = await _solicitudService.ObtenerSolicitudPorId(id);

            if (solicitud == null)
            {
                return NotFound();
            }

            return Ok(solicitud);
        }

        // PUT: api/Solicitudes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitud(int id, SolicitudEstadoDto solicitudEstadoDto)
        {
            if (id != solicitudEstadoDto.SolicitudID)
            {
                return BadRequest();
            }

            // Buscar la solicitud existente
            var solicitud = await _solicitudService.ObtenerSolicitudPorId(id);
            if (solicitud == null)
            {
                return NotFound();
            }

            // Solo actualizar el estado
            solicitud.Estado = solicitudEstadoDto.Estado;

            // Actualizar la solicitud en la base de datos
            await _solicitudService.ActualizarSolicitud(solicitud);

            return Ok(solicitud);
        }

        // GET api/solicitudes
        [HttpGet("filtrar")]
        public async Task<IActionResult> ObtenerSolicitudesPorFiltro([FromQuery] SolicitudFiltroDto filtros)
        {
            // Llamar al servicio para obtener las solicitudes filtradas
            var solicitudes = await _solicitudService.ObtenerSolicitudesPorFiltro(filtros);

            // Si no hay solicitudes, devolver un 404
            if (solicitudes == null || !solicitudes.Any())
            {
                return NotFound(new { mensaje = "No se encontraron solicitudes que coincidan con los filtros." });
            }

            // Devolver las solicitudes encontradas
            return Ok(solicitudes);
        }
    }
}
