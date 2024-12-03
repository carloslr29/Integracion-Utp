using Eventos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Negocio.Eventos
{
    public interface IEventoService
    {
        Task<Evento> RegistrarEvento(Evento evento);
        Task<IEnumerable<Evento>> ObtenerEventos();
        Task<Evento> ObtenerEventoPorId(int id);
        Task<Evento> ActualizarEvento(Evento evento);
    }
}
