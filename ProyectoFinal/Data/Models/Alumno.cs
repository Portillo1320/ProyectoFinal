using System;
using System.Collections.Generic;

namespace ProyectoFinal.Data.Models
{
    public class Alumno
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FecNac { get; set; }

        //Propiedades de vavegacion (se especifican las relaciones)

        
        public List<Alumno_Actividad> Alumno_Actividads { get; set; }
        public List<Alumno_Material> Alumno_Materials { get; set; }
        public List<Alumno_Conducta> Alumno_Conductas { get; set; }
    }
}
