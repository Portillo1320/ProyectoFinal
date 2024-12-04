using System;
using System.Collections.Generic;

namespace ProyectoFinal.Data.ViewModel
{
    public class ConductaVM
    {
        public string Observaciones { get; set; }
        public string CalificacionConducta { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class ConductaWithAlumnoVM
    {
        public string CalificacionConducta { get; set; }
        public List<string> AlumnoName { get; set; }
    }
}
