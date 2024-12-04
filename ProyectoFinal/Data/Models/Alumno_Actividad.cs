namespace ProyectoFinal.Data.Models
{
    public class Alumno_Actividad
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public int ActividadId { get; set; }

        public Actividad Actividad { get; set; }
    }
}
