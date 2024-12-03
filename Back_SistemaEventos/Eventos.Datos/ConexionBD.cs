using Eventos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Datos
{
    public class ConexionBD : DbContext
    {
        public ConexionBD(DbContextOptions<ConexionBD> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        //public DbSet<SolicitudFiltroDto> SolicitudesFiltro { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<DetallePaquete> DetallePaquete { get; set; }
        public DbSet<Evento> Eventos { get; set; }

    }
}
