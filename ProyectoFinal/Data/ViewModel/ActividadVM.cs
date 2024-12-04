using System;
using System.Collections.Generic;

namespace ProyectoFinal.Data.ViewModel
{
    public class ActividadVM
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    }
    public class ActividadWithAlumnoVM
    {
        public string Titulo { get; set; }
        public List<string> AlumnoName { get; set; }
    }
}
