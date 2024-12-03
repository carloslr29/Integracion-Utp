using Eventos.Datos.Eventos;
using Eventos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Negocio.Eventos
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<Evento> RegistrarEvento(Evento evento)
        {
            return await _eventoRepository.RegistrarEvento(evento);
        }

        public async Task<IEnumerable<Evento>> ObtenerEventos()
        {
            return await _eventoRepository.ObtenerEventos();
        }

        public async Task<Evento> ObtenerEventoPorId(int id)
        {
            return await _eventoRepository.ObtenerEventoPorId(id);
        }

        public async Task<Evento> ActualizarEvento(Evento evento)
        {
            return await _eventoRepository.ActualizarEvento(evento);
        }
    }
}
