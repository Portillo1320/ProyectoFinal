using System;
using System.Collections.Generic;

namespace ProyectoFinal.Data.ViewModel
{
    public class AlumnoVM
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FecNac { get; set; }

        public List<int> ActividadIDs { get; set; }
        public List<int> MaterialIDs { get; set; }
        public List<int> ConductaIDs { get; set; }
    }
    public class AlumnoWithClassVM
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        

        public List<string> ActividadNames { get; set; }
        public List<string> MaterialNames { get; set; }
        public List<string> ConductaNames { get; set; }
    }
}
