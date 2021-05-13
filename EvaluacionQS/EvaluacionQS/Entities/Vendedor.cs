using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionQS.Entities
{
    public class Vendedor
    {
        [Key]
        public int VendedorId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}
