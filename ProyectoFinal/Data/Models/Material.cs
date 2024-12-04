using System.Collections.Generic;

namespace ProyectoFinal.Data.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        //Propiedades de navegacion
        public List<Alumno_Material> Alumno_Materials { get; set; }
    }
}
