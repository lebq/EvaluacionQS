using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionQS.Entities
{
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }
        public string Serie { get; set; }
        public string Codigo { get; set; }
        public int VendedorId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Moneda { get; set; }
    }
}
