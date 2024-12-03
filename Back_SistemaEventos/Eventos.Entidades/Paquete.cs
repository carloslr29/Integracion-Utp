using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Entidades
{
    public class Paquete
    {
        [Key]
        public int PaqueteID { get; set; }
        public int EventoID { get; set; }
        public string NombrePaquete { get; set; }
        public string DescripcionPaquete { get; set; }
        public decimal Precio { get; set; }
        public string UrlImagen { get; set; }
        public List<DetallePaquete> DetallePaquete { get; set; }
    }
}
