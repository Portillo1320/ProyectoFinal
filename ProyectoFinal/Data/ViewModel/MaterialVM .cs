using System;
using System.Collections.Generic;

namespace ProyectoFinal.Data.ViewModel
{
    public class MaterialVM
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
    public class MaterialWithAlumnoVM
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<string> AlumnoName { get; set; }
    }
}
