using Eventos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Negocio.Paquetes
{
    public interface IPaqueteService
    {
        Task<Paquete> RegistrarPaquete(Paquete paquete);
        Task<IEnumerable<Paquete>> ObtenerPaquetes();
        Task<IEnumerable<Paquete>> ObtenerPaquetesPorEventoId(int id);
        Task<Paquete> ObtenerPaquetePorId(int id);
        Task<Paquete> ActualizarPaquete(Paquete paquete);
    }
}
