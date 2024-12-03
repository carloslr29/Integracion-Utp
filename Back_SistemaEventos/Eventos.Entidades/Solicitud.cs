using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Entidades
{
    public class Solicitud
    {
        [Key]
        public int SolicitudID { get; set; }
        public int UsuarioID { get; set; }
        public int EventoID { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int CantidadInvitados { get; set; }
        public DateTime FechaEvento { get; set; }
        public string LugarEvento { get; set; }
        public string HorarioPreferencia { get; set; }
        public int PaqueteElegidoID { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaSolicitud { get; set; }
    }
}
