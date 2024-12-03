using Eventos.Entidades;
using Eventos.Negocio.Paquetes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppEventos.Controllers.Paquetes
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaquetesController : Controller
    {
        private readonly IPaqueteService _paqueteService;

        public PaquetesController(IPaqueteService paqueteService)
        {
            _paqueteService = paqueteService;
        }

        // POST: api/Paquetes
        [HttpPost]
        public async Task<ActionResult<Paquete>> PostPaquete(Paquete paquete)
        {
            var nuevoPaquete = await _paqueteService.RegistrarPaquete(paquete);
            return CreatedAtAction(nameof(GetPaquete), new { id = nuevoPaquete.PaqueteID }, nuevoPaquete);
        }

        // GET: api/Paquetes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paquete>>> GetPaquetes()
        {
            var paquetes = await _paqueteService.ObtenerPaquetes();
            return Ok(paquetes);
        }

        // GET: api/Paquete/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paquete>> GetPaquete(int id)
        {
            var paquete = await _paqueteService.ObtenerPaquetePorId(id);

            if (paquete == null)
            {
                return NotFound();
            }

            return Ok(paquete);
        }

        // GET: api/Paquetes
        [HttpGet("PaquetePorEvento/{id}")]
        public async Task<ActionResult<IEnumerable<Paquete>>> GetPaquetesForEvent(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El identificador del evento debe ser mayor que 0.");
            }
            var paquetes = await _paqueteService.ObtenerPaquetesPorEventoId(id);
            if (paquetes == null || !paquetes.Any())
            {
                return NotFound($"No se encontraron paquetes para el evento con ID {id}.");
            }
            return Ok(paquetes);
        }

        // PUT: api/Paquetes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaquete(int id, Paquete paquete)
        {
            if (id != paquete.PaqueteID)
            {
                return BadRequest();
            }

            await _paqueteService.ActualizarPaquete(paquete);

            return NoContent();
        }
    }
}
