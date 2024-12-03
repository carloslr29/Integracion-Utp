using Eventos.Entidades;
using Eventos.Negocio.Eventos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppEventos.Controllers.Eventos
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : Controller
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        // POST: api/Eventos
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {
            var nuevoEvento = await _eventoService.RegistrarEvento(evento);
            return CreatedAtAction(nameof(GetEvento), new { id = nuevoEvento.EventoID }, nuevoEvento);
        }

        // GET: api/Eventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
            var eventos = await _eventoService.ObtenerEventos();
            return Ok(eventos);
        }

        // GET: api/Evento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _eventoService.ObtenerEventoPorId(id);

            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        // PUT: api/Eventos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            if (id != evento.EventoID)
            {
                return BadRequest();
            }

            await _eventoService.ActualizarEvento(evento);

            return NoContent();
        }
    }
}
