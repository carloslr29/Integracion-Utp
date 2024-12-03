using Eventos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Datos.Eventos
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ConexionBD _context;

        public EventoRepository(ConexionBD context)
        {
            _context = context;
        }

        public async Task<Evento> RegistrarEvento(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
            return evento;
        }

        public async Task<IEnumerable<Evento>> ObtenerEventos()
        {
            return await _context.Eventos.ToListAsync();
        }

        public async Task<Evento> ObtenerEventoPorId(int id)
        {
            return await _context.Eventos.FindAsync(id);
        }

        public async Task<Evento> ActualizarEvento(Evento evento)
        {
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
            return evento;
        }
    }
}
