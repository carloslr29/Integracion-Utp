using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Entidades
{
    public class DetallePaquete
    {
        [Key]
        public int DetalleID { get; set; }
        public int PaqueteID { get; set; }
        public string Descripcion { get; set; }
    }
}
