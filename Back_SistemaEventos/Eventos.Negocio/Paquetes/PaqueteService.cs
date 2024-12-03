using Eventos.Datos.Paquetes;
using Eventos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Negocio.Paquetes
{
    public class PaqueteService : IPaqueteService
    {
        private readonly IPaqueteRepository _paqueteRepository;

        public PaqueteService(IPaqueteRepository paqueteRepository)
        {
            _paqueteRepository = paqueteRepository;
        }

        public async Task<Paquete> RegistrarPaquete(Paquete paquete)
        {
            return await _paqueteRepository.RegistrarPaquete(paquete);
        }

        public async Task<IEnumerable<Paquete>> ObtenerPaquetes()
        {
            return await _paqueteRepository.ObtenerPaquetes();
        }

        public async Task<IEnumerable<Paquete>> ObtenerPaquetesPorEventoId(int id)
        {
            return await _paqueteRepository.ObtenerPaquetesPorEventoId(id);
        }

        public async Task<Paquete> ObtenerPaquetePorId(int id)
        {
            return await _paqueteRepository.ObtenerPaquetePorId(id);
        }

        public async Task<Paquete> ActualizarPaquete(Paquete paquete)
        {
            return await _paqueteRepository.ActualizarPaquete(paquete);
        }
    }
}
