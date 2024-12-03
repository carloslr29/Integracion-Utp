using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Entidades
{
    public class Evento
    {
        [Key]
        public int EventoID { get; set; }
        public string NombreEvento { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
    }
}
