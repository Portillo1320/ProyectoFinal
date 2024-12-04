using System;
using System.Collections.Generic;

namespace ProyectoFinal.Data.Models
{
    public class Actividad
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        //Propiedades de navegacion (
        public List<Alumno_Actividad> Alumno_Actividads { get; set; }
    }
}
