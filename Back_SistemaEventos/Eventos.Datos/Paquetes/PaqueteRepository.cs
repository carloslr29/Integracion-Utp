using Eventos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Datos.Paquetes
{
    public class PaqueteRepository : IPaqueteRepository
    {
        private readonly ConexionBD _context;

        public PaqueteRepository(ConexionBD context)
        {
            _context = context;
        }

        public async Task<Paquete> RegistrarPaquete(Paquete paquete)
        {
            _context.Paquetes.Add(paquete);
            await _context.SaveChangesAsync();
            return paquete;
        }

        public async Task<IEnumerable<Paquete>> ObtenerPaquetes()
        {
            return await _context.Paquetes.ToListAsync();
        }

        public async Task<IEnumerable<Paquete>> ObtenerPaquetesPorEventoId(int id)
        {
            return await _context.Paquetes
                         .Include(p => p.DetallePaquete)
                         .Where(p => p.EventoID == id) // Filtra los paquetes por idEvento
                         .ToListAsync(); // Ejecuta la consulta y devuelve una lista
        }

        public async Task<Paquete> ObtenerPaquetePorId(int id)
        {
            return await _context.Paquetes.FindAsync(id);
        }

        public async Task<Paquete> ActualizarPaquete(Paquete paquete)
        {
            _context.Paquetes.Update(paquete);
            await _context.SaveChangesAsync();
            return paquete;
        }
    }
}
