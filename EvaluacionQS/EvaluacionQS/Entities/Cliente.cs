﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionQS.Entities
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Nic { get; set; }
        public string Categoria { get; set; }
    }
}
