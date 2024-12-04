using System.Collections.Generic;
using System;

namespace ProyectoFinal.Data.Models
{
    public class Conducta
    {
        public int Id { get; set; }
        public string Observaciones { get; set; }
        public string CalificacionConducta { get; set; } // "Buena", "Regular", "Mala"
        public DateTime Fecha { get; set; }

        //Propiedades de navegacion (

        public List<Alumno_Conducta> Alumno_Conductas { get; set; }
    }
}
