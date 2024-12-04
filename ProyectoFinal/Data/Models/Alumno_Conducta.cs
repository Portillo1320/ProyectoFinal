namespace ProyectoFinal.Data.Models
{
    public class Alumno_Conducta
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public int ConductaId { get; set; }

        public Conducta Conducta { get; set; }
    }
}
