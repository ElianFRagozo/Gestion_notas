using System;
using System.Collections.Generic;

namespace ProyectoNotas.Models
{

    public partial class Nota
    {
        public int Idnota { get; set; }

        public string? Titulo { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? FechaNota { get; set; }

        public DateTime? FechaRegistro { get; set; }

    }
}
