namespace ProyectoFinal.Data.Models
{
    public class Alumno_Material
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public int MaterialId { get; set; }

        public Material Material { get; set; }
    }
}
