using Eventos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Datos.Eventos
{
    public interface IEventoRepository
    {
        Task<Evento> RegistrarEvento(Evento evento);
        Task<IEnumerable<Evento>> ObtenerEventos();
        Task<Evento> ObtenerEventoPorId(int id);
        Task<Evento> ActualizarEvento(Evento evento);
    }
}
